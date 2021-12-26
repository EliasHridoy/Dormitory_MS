using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DomMS.Models
{
    public partial class Room
    {
        public Room()
        {
            Bookings = new HashSet<Bookings>();
        }

        public long RoomId { get; set; }
        public int? FloorNo { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool? IsKitchen { get; set; }
        public DateTime EntryDate { get; set; }

        public virtual ICollection<Bookings> Bookings { get; set; }
    }
}
