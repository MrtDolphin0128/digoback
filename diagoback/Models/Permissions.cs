using System;
using System.Collections.Generic;

namespace diagoback.Models
{
    public partial class Permissions
    {
        public Permissions()
        {
            RolePermissions = new HashSet<RolePermissions>();
            UserPermissions = new HashSet<UserPermissions>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }

        public virtual ICollection<RolePermissions> RolePermissions { get; set; }
        public virtual ICollection<UserPermissions> UserPermissions { get; set; }
    }
}
