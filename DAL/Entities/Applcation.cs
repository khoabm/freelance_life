using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class Applcation
    {
        public int Id { get; set; }
        public int FreelancerId { get; set; }
        public int JobId { get; set; }
        public DateTime ApplyDate { get; set; }
        public short Status { get; set; }

        public virtual User Freelancer { get; set; } = null!;
        public virtual Job Job { get; set; } = null!;
    }
}
