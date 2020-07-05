using System;
using System.Collections.Generic;

namespace diagoback.Models
{
    public partial class UserCompanies
    {
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public string UserType { get; set; }
    }
}
