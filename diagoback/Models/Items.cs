using System;
using System.Collections.Generic;

namespace diagoback.Models
{
    public partial class Items
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Sku { get; set; }
        public string Description { get; set; }
        public double SalePrice { get; set; }
        public double PurchasePrice { get; set; }
        public int Quantity { get; set; }
        public int? CategoryId { get; set; }
        public int? TaxId { get; set; }
        public byte Enabled { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
