using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class Task
    {
        public Task()
        {
            TaskReviews = new HashSet<TaskReview>();
        }

        public int Id { get; set; }
        public int JobId { get; set; }
        public int FreelancerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public short Status { get; set; }

        public virtual User Freelancer { get; set; } = null!;
        public virtual Job Job { get; set; } = null!;
        public virtual ICollection<TaskReview> TaskReviews { get; set; }
    }
}
