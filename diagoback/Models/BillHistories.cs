using System;
using System.Collections.Generic;

namespace diagoback.Models
{
    public partial class BillHistories
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int BillId { get; set; }
        public string Status { get; set; }
        public byte Notify { get; set; }
        public string Description { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
