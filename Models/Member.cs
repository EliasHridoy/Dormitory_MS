using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DomMS.Models
{
    public partial class Member
    {
        public Member()
        {
            Bookings = new HashSet<Bookings>();
        }

        public long MemberId { get; set; }
        public string IdToken { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }

        public virtual ICollection<Bookings> Bookings { get; set; }
    }
}
