using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class JobStatus
    {
        public int JobId { get; set; }
        public int FreelancerId { get; set; }
        public short Status { get; set; }

        public virtual Freelancer Freelancer { get; set; } = null!;
        public virtual Job Job { get; set; } = null!;
    }
}
