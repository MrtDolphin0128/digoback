using System;
using System.Collections.Generic;

namespace diagoback.Models
{
    public partial class UserDashboards
    {
        public int UserId { get; set; }
        public int DashboardId { get; set; }
        public string UserType { get; set; }
    }
}
