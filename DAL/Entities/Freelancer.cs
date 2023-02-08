using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class Freelancer
    {
        public Freelancer()
        {
            JobStatuses = new HashSet<JobStatus>();
        }

        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public DateTime? DateOfBirth { get; set; }

        public virtual ICollection<JobStatus> JobStatuses { get; set; }
    }
}
