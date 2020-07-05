using System;
using System.Collections.Generic;

namespace diagoback.Models
{
    public partial class Taxes
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public double Rate { get; set; }
        public string Type { get; set; }
        public byte Enabled { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
