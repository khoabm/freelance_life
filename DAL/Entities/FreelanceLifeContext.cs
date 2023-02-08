using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.Entities
{
    public partial class FreelanceLifeContext : DbContext
    {
        public FreelanceLifeContext()
        {
        }

        public FreelanceLifeContext(DbContextOptions<FreelanceLifeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Applcation> Applcations { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Cv> Cvs { get; set; } = null!;
        public virtual DbSet<Freelancer> Freelancers { get; set; } = null!;
        public virtual DbSet<Job> Jobs { get; set; } = null!;
        public virtual DbSet<JobStatus> JobStatuses { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<Notification> Notifications { get; set; } = null!;
        public virtual DbSet<Rating> Ratings { get; set; } = null!;
        public virtual DbSet<Recruiter> Recruiters { get; set; } = null!;
        public virtual DbSet<Report> Reports { get; set; } = null!;
        public virtual DbSet<ReportType> ReportTypes { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Skill> Skills { get; set; } = null!;
        public virtual DbSet<Task> Tasks { get; set; } = null!;
        public virtual DbSet<TaskReview> TaskReviews { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local);Uid=sa;Pwd=khoa;Database=FreelanceLife");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Applcation>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ApplyDate).HasColumnName("apply_date");

                entity.Property(e => e.FreelancerId).HasColumnName("freelancer_id");

                entity.Property(e => e.JobId).HasColumnName("job_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Freelancer)
                    .WithMany(p => p.Applcations)
                    .HasForeignKey(d => d.FreelancerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Applcatio__freel__4CA06362");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Applcations)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Applcatio__job_i__4D94879B");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Cv>(entity =>
            {
                entity.ToTable("CV");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FileName)
                    .HasMaxLength(50)
                    .HasColumnName("file_name")
                    .IsFixedLength();

                entity.Property(e => e.FilePath)
                    .HasMaxLength(500)
                    .HasColumnName("file_path")
                    .IsFixedLength();

                entity.Property(e => e.FreelancerId).HasColumnName("freelancer_id");

                entity.HasOne(d => d.Freelancer)
                    .WithMany(p => p.Cvs)
                    .HasForeignKey(d => d.FreelancerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CV__freelancer_i__398D8EEE");
            });

            modelBuilder.Entity<Freelancer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");

                entity.Property(e => e.FullName)
                    .HasMaxLength(50)
                    .HasColumnName("full_name");

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("gender")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BudgetMax)
                    .HasColumnType("money")
                    .HasColumnName("budget_max");

                entity.Property(e => e.BudgetMin)
                    .HasColumnType("money")
                    .HasColumnName("budget_min");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.EndDate).HasColumnName("end_date");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.PostDate).HasColumnName("post_date");

                entity.Property(e => e.RecruiterId).HasColumnName("recruiter_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .HasColumnName("title");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Jobs__category_i__44FF419A");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Jobs__location_i__45F365D3");

                entity.HasOne(d => d.Recruiter)
                    .WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.RecruiterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Jobs__recruiter___440B1D61");

                entity.HasMany(d => d.Skills)
                    .WithMany(p => p.Jobs)
                    .UsingEntity<Dictionary<string, object>>(
                        "JobSkill",
                        l => l.HasOne<Skill>().WithMany().HasForeignKey("SkillId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__JobSkills__skill__48CFD27E"),
                        r => r.HasOne<Job>().WithMany().HasForeignKey("JobId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__JobSkills__job_i__49C3F6B7"),
                        j =>
                        {
                            j.HasKey("JobId", "SkillId").HasName("PK__JobSkill__E1891E92218F51F8");

                            j.ToTable("JobSkills");

                            j.IndexerProperty<int>("JobId").HasColumnName("job_id");

                            j.IndexerProperty<int>("SkillId").HasColumnName("skill_id");
                        });
            });

            modelBuilder.Entity<JobStatus>(entity =>
            {
                entity.HasKey(e => new { e.JobId, e.FreelancerId })
                    .HasName("PK__JobStatu__7CA06767674AE811");

                entity.ToTable("JobStatus");

                entity.Property(e => e.JobId).HasColumnName("job_id");

                entity.Property(e => e.FreelancerId).HasColumnName("freelancer_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Freelancer)
                    .WithMany(p => p.JobStatuses)
                    .HasForeignKey(d => d.FreelancerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__JobStatus__freel__59063A47");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.JobStatuses)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__JobStatus__job_i__5812160E");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Detail).HasColumnName("detail");

                entity.Property(e => e.ReceiverId).HasColumnName("receiver_id");

                entity.HasOne(d => d.Receiver)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.ReceiverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Notificat__recei__2E1BDC42");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("Rating");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.RateeId).HasColumnName("ratee_id");

                entity.Property(e => e.RaterId).HasColumnName("rater_id");

                entity.Property(e => e.Rating1).HasColumnName("rating");

                entity.HasOne(d => d.Ratee)
                    .WithMany(p => p.RatingRatees)
                    .HasForeignKey(d => d.RateeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rating__ratee_id__2A4B4B5E");

                entity.HasOne(d => d.Rater)
                    .WithMany(p => p.RatingRaters)
                    .HasForeignKey(d => d.RaterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rating__rater_id__2B3F6F97");
            });

            modelBuilder.Entity<Recruiter>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(100)
                    .HasColumnName("company_name");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("Report");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Detail).HasColumnName("detail");

                entity.Property(e => e.Picture)
                    .HasMaxLength(500)
                    .HasColumnName("picture")
                    .IsFixedLength();

                entity.Property(e => e.ReporteeId).HasColumnName("reportee_id");

                entity.Property(e => e.ReporterId).HasColumnName("reporter_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .HasColumnName("title");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.HasOne(d => d.Reportee)
                    .WithMany(p => p.ReportReportees)
                    .HasForeignKey(d => d.ReporteeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Report__reportee__33D4B598");

                entity.HasOne(d => d.Reporter)
                    .WithMany(p => p.ReportReporters)
                    .HasForeignKey(d => d.ReporterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Report__reporter__32E0915F");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Report__type_id__34C8D9D1");
            });

            modelBuilder.Entity<ReportType>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("PK__ReportTy__2C000598FA87EDF4");

                entity.ToTable("ReportType");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .HasColumnName("name")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.EndDate).HasColumnName("end_date");

                entity.Property(e => e.FreelancerId).HasColumnName("freelancer_id");

                entity.Property(e => e.JobId).HasColumnName("job_id");

                entity.Property(e => e.StartDate).HasColumnName("start_date");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .HasColumnName("title");

                entity.HasOne(d => d.Freelancer)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.FreelancerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Tasks__freelance__5165187F");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Tasks__job_id__5070F446");
            });

            modelBuilder.Entity<TaskReview>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Review).HasColumnName("review");

                entity.Property(e => e.ReviewDate).HasColumnName("review_date");

                entity.Property(e => e.ReviewerId).HasColumnName("reviewer_id");

                entity.Property(e => e.TaskId).HasColumnName("task_id");

                entity.HasOne(d => d.Reviewer)
                    .WithMany(p => p.TaskReviews)
                    .HasForeignKey(d => d.ReviewerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TaskRevie__revie__5535A963");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.TaskReviews)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TaskRevie__task___5441852A");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Emai, "UQ__Users__3F33C30AE63B5858")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .HasColumnName("address");

                entity.Property(e => e.Emai)
                    .HasMaxLength(50)
                    .HasColumnName("emai")
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .HasColumnName("phone")
                    .IsFixedLength();

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .HasColumnName("user_name");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__role_id__276EDEB3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
