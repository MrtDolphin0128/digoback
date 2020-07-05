using System;
using System.Collections.Generic;

namespace diagoback.Models
{
    public partial class ModuleHistories
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int ModuleId { get; set; }
        public string Category { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
