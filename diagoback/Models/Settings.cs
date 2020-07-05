using System;
using System.Collections.Generic;

namespace diagoback.Models
{
    public partial class Settings
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
