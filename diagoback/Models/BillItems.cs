﻿using System;
using System.Collections.Generic;

namespace diagoback.Models
{
    public partial class BillItems
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int BillId { get; set; }
        public int? ItemId { get; set; }
        public string Name { get; set; }
        public string Sku { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }
        public double Tax { get; set; }
        public double DiscountRate { get; set; }
        public string DiscountType { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
