using WebApplication1.Models;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using WebApplication1.AppDbContext;

[Route("api/[controller]")]
[ApiController]
public class AppController : ControllerBase
{
    private readonly ApdbDbContext _context;

    public AppController(ApdbDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskDto>>> GetTasks(int? projectId)
    {
        var tasks = _context.Tasks
            .Include(t => t.Reporter)
            .Include(t => t.Assignee)
            .AsQueryable();

        if (projectId.HasValue)
        {
            tasks = tasks.Where(t => t.IdProject == projectId);
        }

        var result = await tasks.Select(t => new TaskDto
        {
            Id = t.IdTask,
            Name = t.Name,
            Description = t.Description,
            CreatedAt = t.CreatedAt,
            ProjectId = t.IdProject,
            Reporter = t.Reporter != null ? new UserDto { Id = t.Reporter.IdUser, FirstName = t.Reporter.FirstName, LastName = t.Reporter.LastName } : null,
            Assignee = t.Assignee != null ? new UserDto { Id = t.Assignee.IdUser, FirstName = t.Assignee.FirstName, LastName = t.Assignee.LastName } : null
        }).ToListAsync();

        return result;
    }

    [HttpPost]
    public async Task<ActionResult<TaskDto>> CreateTask(CreateTaskDto taskDto)
    {
        var project = await _context.Projects.FindAsync(taskDto.ProjectId);
        if (project == null)
            return NotFound("Project not found.");

        var reporter = await _context.Users.FindAsync(taskDto.ReporterId);
        if (reporter == null)
            return NotFound("Reporter not found.");

        var assignee = taskDto.AssigneeId.HasValue ? await _context.Users.FindAsync(taskDto.AssigneeId.Value) : null;
        if (taskDto.AssigneeId.HasValue && assignee == null)
            return NotFound("Assignee not found.");

        bool accessToProject = _context.Accesses.Any(a => a.IdProject == taskDto.ProjectId && (a.IdUser == taskDto.ReporterId || (assignee != null && a.IdUser == assignee.IdUser)));
        if (!accessToProject)
            return BadRequest("Reporter and/or Assignee do not have access to the project.");

        var task = new Taskk
        {
            Name = taskDto.Name,
            Description = taskDto.Description,
            CreatedAt = DateTime.UtcNow,
            IdProject = taskDto.ProjectId,
            IdReporter = taskDto.ReporterId,
            IdAssignee = taskDto.AssigneeId ?? project.IdDefaultAssignee
        };

        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();

        var createdTask = new TaskDto
        {
            Id = task.IdTask,
            Name = task.Name,
            Description = task.Description,
            CreatedAt = task.CreatedAt,
            ProjectId = task.IdProject,
            Reporter = new UserDto { Id = reporter.IdUser, FirstName = reporter.FirstName, LastName = reporter.LastName },
            Assignee = assignee != null ? new UserDto { Id = assignee.IdUser, FirstName = assignee.FirstName, LastName = assignee.LastName } : null
        };

        return CreatedAtAction(nameof(GetTasks), new { id = task.IdTask }, createdTask);
    }
}