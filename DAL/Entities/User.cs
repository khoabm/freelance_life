using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class User
    {
        public User()
        {
            Applcations = new HashSet<Applcation>();
            Cvs = new HashSet<Cv>();
            Notifications = new HashSet<Notification>();
            RatingRatees = new HashSet<Rating>();
            RatingRaters = new HashSet<Rating>();
            ReportReportees = new HashSet<Report>();
            ReportReporters = new HashSet<Report>();
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Emai { get; set; } = null!;
        public string? Address { get; set; }
        public short RoleId { get; set; }
        public short Status { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Applcation> Applcations { get; set; }
        public virtual ICollection<Cv> Cvs { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Rating> RatingRatees { get; set; }
        public virtual ICollection<Rating> RatingRaters { get; set; }
        public virtual ICollection<Report> ReportReportees { get; set; }
        public virtual ICollection<Report> ReportReporters { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
