using System;
using System.Collections.Generic;

namespace diagoback.Models
{
    public partial class Media
    {
        public Media()
        {
            Mediables = new HashSet<Mediables>();
        }

        public int Id { get; set; }
        public string Disk { get; set; }
        public string Directory { get; set; }
        public string Filename { get; set; }
        public string Extension { get; set; }
        public string MimeType { get; set; }
        public string AggregateType { get; set; }
        public int Size { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }

        public virtual ICollection<Mediables> Mediables { get; set; }
    }
}
