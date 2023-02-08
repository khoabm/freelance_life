using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class Recruiter
    {
        public Recruiter()
        {
            Jobs = new HashSet<Job>();
            TaskReviews = new HashSet<TaskReview>();
        }

        public int Id { get; set; }
        public string CompanyName { get; set; } = null!;

        public virtual ICollection<Job> Jobs { get; set; }
        public virtual ICollection<TaskReview> TaskReviews { get; set; }
    }
}
