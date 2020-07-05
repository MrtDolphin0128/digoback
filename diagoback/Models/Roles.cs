using System;
using System.Collections.Generic;

namespace diagoback.Models
{
    public partial class Roles
    {
        public Roles()
        {
            RolePermissions = new HashSet<RolePermissions>();
            UserRoles = new HashSet<UserRoles>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }

        public virtual ICollection<RolePermissions> RolePermissions { get; set; }
        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
