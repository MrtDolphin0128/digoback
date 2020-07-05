using System;
using System.Collections.Generic;

namespace diagoback.Models
{
    public partial class FirewallLogs
    {
        public int Id { get; set; }
        public string Ip { get; set; }
        public string Level { get; set; }
        public string Middleware { get; set; }
        public int? UserId { get; set; }
        public string Url { get; set; }
        public string Referrer { get; set; }
        public string Request { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
