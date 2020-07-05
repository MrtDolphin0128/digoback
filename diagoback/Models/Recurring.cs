using System;
using System.Collections.Generic;

namespace diagoback.Models
{
    public partial class Recurring
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string RecurableType { get; set; }
        public long RecurableId { get; set; }
        public string Frequency { get; set; }
        public int Interval { get; set; }
        public DateTime StartedAt { get; set; }
        public int Count { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
