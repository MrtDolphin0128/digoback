using System;
using System.Collections.Generic;

namespace diagoback.Models
{
    public partial class Modules
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Alias { get; set; }
        public int Enabled { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
