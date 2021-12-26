using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DomMS.Models
{
    public partial class Bookings
    {
        public long BookingId { get; set; }
        public long MemberId { get; set; }
        public long RoomId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public TimeSpan? FromTime { get; set; }
        public TimeSpan? ToTime { get; set; }
        public DateTime EntryDate { get; set; }

        public virtual Member Member { get; set; }
        public virtual Room Room { get; set; }
    }
}
