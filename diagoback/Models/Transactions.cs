using System;
using System.Collections.Generic;

namespace diagoback.Models
{
    public partial class Transactions
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Type { get; set; }
        public DateTime PaidAt { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public double CurrencyRate { get; set; }
        public int AccountId { get; set; }
        public int? DocumentId { get; set; }
        public int? ContactId { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public string PaymentMethod { get; set; }
        public string Reference { get; set; }
        public int ParentId { get; set; }
        public byte Reconciled { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
