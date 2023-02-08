using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class Job
    {
        public Job()
        {
            Applcations = new HashSet<Applcation>();
            JobStatuses = new HashSet<JobStatus>();
            Tasks = new HashSet<Task>();
            Skills = new HashSet<Skill>();
        }

        public int Id { get; set; }
        public int RecruiterId { get; set; }
        public int CategoryId { get; set; }
        public int LocationId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime PostDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal BudgetMin { get; set; }
        public decimal BudgetMax { get; set; }
        public short Status { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual Location Location { get; set; } = null!;
        public virtual Recruiter Recruiter { get; set; } = null!;
        public virtual ICollection<Applcation> Applcations { get; set; }
        public virtual ICollection<JobStatus> JobStatuses { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }

        public virtual ICollection<Skill> Skills { get; set; }
    }
}
