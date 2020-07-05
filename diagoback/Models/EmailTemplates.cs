using System;
using System.Collections.Generic;

namespace diagoback.Models
{
    public partial class EmailTemplates
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Alias { get; set; }
        public string Class { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Params { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
