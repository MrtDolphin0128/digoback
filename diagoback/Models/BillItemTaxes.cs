using System;
using System.Collections.Generic;

namespace diagoback.Models
{
    public partial class BillItemTaxes
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int BillId { get; set; }
        public int BillItemId { get; set; }
        public int TaxId { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
