using System;
using System.Collections.Generic;

namespace diagoback.Models
{
    public partial class Companies
    {
        public int Id { get; set; }
        public string Domain { get; set; }
        public byte Enabled { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
