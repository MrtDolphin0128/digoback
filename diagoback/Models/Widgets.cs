using System;
using System.Collections.Generic;

namespace diagoback.Models
{
    public partial class Widgets
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int DashboardId { get; set; }
        public string Class { get; set; }
        public string Name { get; set; }
        public int Sort { get; set; }
        public string Settings { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
