﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DomMS.Models
{
    public partial class Users
    {
        public long UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
