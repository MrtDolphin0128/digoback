using System;
using System.Collections.Generic;

namespace diagoback.Models
{
    public partial class Reconciliations
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int AccountId { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }
        public double ClosingBalance { get; set; }
        public byte Reconciled { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
