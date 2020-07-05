using System;
using System.Collections.Generic;

namespace diagoback.Models
{
    public partial class InvoiceTotals
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int InvoiceId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public int SortOrder { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
