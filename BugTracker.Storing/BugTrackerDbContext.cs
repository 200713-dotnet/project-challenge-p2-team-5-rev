using System;
using BugTracker.Storing.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BugTracker.Storing
{
    public partial class BugTrackerDbContext : DbContext
    {
        public BugTrackerDbContext()
        {
        }

        public BugTrackerDbContext(DbContextOptions<BugTrackerDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<TicketPriority> TicketPriority { get; set; }
        public virtual DbSet<TicketStatus> TicketStatus { get; set; }
        public virtual DbSet<TicketType> TicketType { get; set; }
        public virtual DbSet<UserProject> UserProject { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment", "Tickets");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.Commenter)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.CommenterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CommenterId");

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.TicketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TicketId");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project", "Projects");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.ManagedProjects)
                    .HasForeignKey(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ManagerId");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("Ticket", "Tickets");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Dev)
                    .WithMany(p => p.AssignedTickets)
                    .HasForeignKey(d => d.DevId)
                    .HasConstraintName("FK_DevId");

                entity.HasOne(d => d.Priority)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.PriorityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PriorityId");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectId");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StatusId");

                entity.HasOne(d => d.Submitter)
                    .WithMany(p => p.SubmittedTickets)
                    .HasForeignKey(d => d.SubmitterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubmitterId");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TypeId");

                entity.HasOne(d => d.Updater)
                    .WithMany(p => p.UpdatedTickets)
                    .HasForeignKey(d => d.UpdaterId)
                    .HasConstraintName("FK_UpdaterId");

                entity.Property(d => d.ValidFrom).HasDefaultValue();
                entity.Property(d => d.ValidTo).HasDefaultValue();
            });

            modelBuilder.Entity<TicketPriority>(entity =>
            {
                entity.HasKey(e => e.PriorityId)
                    .HasName("PK_PriorityId");

                entity.ToTable("TicketPriority", "Tickets");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__TicketPr__737584F669391C39")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TicketStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PK_StatusId");

                entity.ToTable("TicketStatus", "Tickets");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__TicketSt__737584F6CFF635AF")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TicketType>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("PK_TypeId");

                entity.ToTable("TicketType", "Tickets");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__TicketTy__737584F655380270")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserProject>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ProjectId })
                    .HasName("PK_UserProjectId");

                entity.ToTable("UserProject", "Users");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.UserProjects)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserProjects)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserId");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK_RoleId");

                entity.ToTable("UserRole", "Users");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__UserRole__737584F60A626405")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_UserId");

                entity.ToTable("Users", "Users");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Users__A9D105348D64F179")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleId");
            });

            modelBuilder.Entity<UserRole>().HasData(new Models.UserRole()
            {
                RoleId = -1,
                Name = "Admin"
            });

            modelBuilder.Entity<TicketPriority>().HasData(new Models.TicketPriority()
            {
                PriorityId = -1,
                Name = "High"
            });

            modelBuilder.Entity<TicketStatus>().HasData(new Models.TicketStatus()
            {
                StatusId = -1,
                Name = "Open"
            });

            modelBuilder.Entity<TicketType>().HasData(new Models.TicketType()
            {
                TypeId = -1,
                Name = "Bug/Error"
            });

            modelBuilder.Entity<Users>().HasData(new Models.Users()
            {
                UserId = -1,
                FirstName = "firstname",
                LastName = "lastname",
                Email = "email",
                RoleId = -1
            });

            modelBuilder.Entity<Project>().HasData(new Models.Project()
            {
                ProjectId = -1,
                Title = "title",
                Description = "description",
                ManagerId = -1
            });

            modelBuilder.Entity<Ticket>().HasData(new Models.Ticket()
            {
                TicketId = -1,
                Title = "title",
                Description = "description",
                SubmitterId = -1,
                ProjectId = -1,
                PriorityId = -1,
                StatusId = -1,
                TypeId = -1,
                DateCreated = DateTime.UtcNow,
                ValidFrom = DateTime.UtcNow,
                ValidTo = DateTime.UtcNow
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
