using System;
using System.Collections.Generic;

namespace diagoback.Models
{
    public partial class Currencies
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public double Rate { get; set; }
        public string Precision { get; set; }
        public string Symbol { get; set; }
        public int SymbolFirst { get; set; }
        public string DecimalMark { get; set; }
        public string ThousandsSeparator { get; set; }
        public byte Enabled { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
