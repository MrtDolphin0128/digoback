using System;
using System.Collections.Generic;

namespace diagoback.Models
{
    public partial class Mediables
    {
        public int MediaId { get; set; }
        public string MediableType { get; set; }
        public int MediableId { get; set; }
        public string Tag { get; set; }
        public int Order { get; set; }

        public virtual Media Media { get; set; }
    }
}
