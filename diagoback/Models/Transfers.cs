using System;
using System.Collections.Generic;

namespace diagoback.Models
{
    public partial class Transfers
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int ExpenseTransactionId { get; set; }
        public int IncomeTransactionId { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
