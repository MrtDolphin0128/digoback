using System;
using System.Collections.Generic;

namespace diagoback.Models
{
    public partial class Accounts
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string CurrencyCode { get; set; }
        public double OpeningBalance { get; set; }
        public string BankName { get; set; }
        public string BankPhone { get; set; }
        public string BankAddress { get; set; }
        public byte Enabled { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
