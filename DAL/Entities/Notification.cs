using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class Notification
    {
        public int Id { get; set; }
        public int ReceiverId { get; set; }
        public DateTime Date { get; set; }
        public string Detail { get; set; } = null!;

        public virtual User Receiver { get; set; } = null!;
    }
}
