using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class ReportType
    {
        public ReportType()
        {
            Reports = new HashSet<Report>();
        }

        public int TypeId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Report> Reports { get; set; }
    }
}
