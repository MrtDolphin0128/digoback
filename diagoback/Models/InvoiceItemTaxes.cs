using System;
using System.Collections.Generic;

namespace diagoback.Models
{
    public partial class InvoiceItemTaxes
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int InvoiceId { get; set; }
        public int InvoiceItemId { get; set; }
        public int TaxId { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
