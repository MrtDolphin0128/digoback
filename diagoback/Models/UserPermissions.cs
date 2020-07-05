using System;
using System.Collections.Generic;

namespace diagoback.Models
{
    public partial class UserPermissions
    {
        public int UserId { get; set; }
        public int PermissionId { get; set; }
        public string UserType { get; set; }

        public virtual Permissions Permission { get; set; }
    }
}
