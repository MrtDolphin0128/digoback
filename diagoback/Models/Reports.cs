using System;
using System.Collections.Generic;

namespace diagoback.Models
{
    public partial class Reports
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Class { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Settings { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
