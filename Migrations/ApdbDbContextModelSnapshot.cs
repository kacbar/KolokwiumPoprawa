﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.AppDbContext;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(ApdbDbContext))]
    partial class ApdbDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.Models.Access", b =>
                {
                    b.Property<int>("IdProject")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.HasKey("IdProject", "IdUser");

                    b.HasIndex("IdUser");

                    b.ToTable("Accesses");
                });

            modelBuilder.Entity("WebApplication1.Models.Project", b =>
                {
                    b.Property<int>("IdProject")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProject"));

                    b.Property<int>("IdDefaultAssignee")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdProject");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("WebApplication1.Models.Taskk", b =>
                {
                    b.Property<int>("IdTask")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTask"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("IdAssignee")
                        .HasColumnType("int");

                    b.Property<int>("IdProject")
                        .HasColumnType("int");

                    b.Property<int>("IdReporter")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdTask");

                    b.HasIndex("IdAssignee");

                    b.HasIndex("IdProject");

                    b.HasIndex("IdReporter");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("WebApplication1.Models.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUser"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdUser");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebApplication1.Models.Access", b =>
                {
                    b.HasOne("WebApplication1.Models.Project", "Project")
                        .WithMany("Accesses")
                        .HasForeignKey("IdProject")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.User", "User")
                        .WithMany("Accesses")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebApplication1.Models.Taskk", b =>
                {
                    b.HasOne("WebApplication1.Models.User", "Assignee")
                        .WithMany("AssignedTasks")
                        .HasForeignKey("IdAssignee")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WebApplication1.Models.Project", "Project")
                        .WithMany("Tasks")
                        .HasForeignKey("IdProject")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.User", "Reporter")
                        .WithMany("ReportedTasks")
                        .HasForeignKey("IdReporter")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Assignee");

                    b.Navigation("Project");

                    b.Navigation("Reporter");
                });

            modelBuilder.Entity("WebApplication1.Models.Project", b =>
                {
                    b.Navigation("Accesses");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("WebApplication1.Models.User", b =>
                {
                    b.Navigation("Accesses");

                    b.Navigation("AssignedTasks");

                    b.Navigation("ReportedTasks");
                });
#pragma warning restore 612, 618
        }
    }
}
