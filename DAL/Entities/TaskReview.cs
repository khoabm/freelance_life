using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class TaskReview
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int ReviewerId { get; set; }
        public string Review { get; set; } = null!;
        public DateTime ReviewDate { get; set; }

        public virtual Recruiter Reviewer { get; set; } = null!;
        public virtual Task Task { get; set; } = null!;
    }
}
