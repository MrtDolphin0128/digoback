using System;
using System.Collections.Generic;

namespace diagoback.Models
{
    public partial class FirewallIps
    {
        public int Id { get; set; }
        public string Ip { get; set; }
        public int? LogId { get; set; }
        public byte Blocked { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
