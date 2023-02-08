using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class Cv
    {
        public int Id { get; set; }
        public int FreelancerId { get; set; }
        public string FileName { get; set; } = null!;
        public string FilePath { get; set; } = null!;

        public virtual User Freelancer { get; set; } = null!;
    }
}
