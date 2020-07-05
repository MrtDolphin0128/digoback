using System;
using System.Collections.Generic;

namespace diagoback.Models
{
    public partial class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RememberToken { get; set; }
        public DateTimeOffset? LastLoggedInAt { get; set; }
        public string Locale { get; set; }
        public string LandingPage { get; set; }
        public byte Enabled { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
