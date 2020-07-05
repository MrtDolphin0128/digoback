using System;
using System.Collections.Generic;

namespace diagoback.Models
{
    public partial class UserRoles
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string UserType { get; set; }

        public virtual Roles Role { get; set; }
    }
}
