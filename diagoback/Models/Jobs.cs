using System;
using System.Collections.Generic;

namespace diagoback.Models
{
    public partial class Jobs
    {
        public long Id { get; set; }
        public string Queue { get; set; }
        public string Payload { get; set; }
        public byte Attempts { get; set; }
        public int? ReservedAt { get; set; }
        public int AvailableAt { get; set; }
        public int CreatedAt { get; set; }
    }
}
