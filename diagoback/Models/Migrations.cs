using System;
using System.Collections.Generic;

namespace diagoback.Models
{
    public partial class Migrations
    {
        public int Id { get; set; }
        public string Migration { get; set; }
        public int Batch { get; set; }
    }
}
