using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class Location
    {
        public Location()
        {
            Jobs = new HashSet<Job>();
        }

        public int LocationId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
