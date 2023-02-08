using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class Report
    {
        public int Id { get; set; }
        public int ReporterId { get; set; }
        public int ReporteeId { get; set; }
        public int TypeId { get; set; }
        public string Title { get; set; } = null!;
        public string Detail { get; set; } = null!;
        public DateTime Date { get; set; }
        public string? Picture { get; set; }
        public int Status { get; set; }

        public virtual User Reportee { get; set; } = null!;
        public virtual User Reporter { get; set; } = null!;
        public virtual ReportType Type { get; set; } = null!;
    }
}
