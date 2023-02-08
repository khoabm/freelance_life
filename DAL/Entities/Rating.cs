using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class Rating
    {
        public int Id { get; set; }
        public int RateeId { get; set; }
        public int RaterId { get; set; }
        public double Rating1 { get; set; }
        public string? Comment { get; set; }

        public virtual User Ratee { get; set; } = null!;
        public virtual User Rater { get; set; } = null!;
    }
}
