using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;


namespace Infrastructures.Core
{
    public class KanbanContext : DbContext
    {
        public KanbanContext(DbContextOptions<KanbanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Board> Boards { get; set; }
        public virtual DbSet<BoardUser> BoardUsers { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<TaskUser> TaskUsers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Board>(entity =>
            {
                entity.ToTable("Board");

                entity.Property(e => e.BoardName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<BoardUser>(entity =>
            {
                entity.HasKey(e => new { e.BoardId, e.UserId });

                entity.ToTable("BoardUser");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Board)
                    .WithMany(p => p.BoardUsers)
                    .HasForeignKey(d => d.BoardId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Board_BoardUser");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BoardUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_User_BoardUser");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");


                entity.Property(e => e.Description)
                    .IsRequired();
                    
                entity.HasOne(d => d.Task)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TaskComment");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.StatusType)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("Tag");

                entity.Property(e => e.Tagname)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("Task");

                entity.Property(e => e.Description);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Board)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.BoardId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TaskBoard")
                    .IsRequired();

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_TaskStatus");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.TagId)
                    .HasConstraintName("FK_TaskTag");
            });

            modelBuilder.Entity<TaskUser>(entity =>
            {
                entity.HasKey(e => new { e.TaskId, e.UserId });

                entity.ToTable("TaskUser");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.TaskUsers)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_task_TaskUser");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TaskUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_User_TaskUser");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(100);
            });
            
        }
    }
}
