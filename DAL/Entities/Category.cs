using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class Category
    {
        public Category()
        {
            Jobs = new HashSet<Job>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
