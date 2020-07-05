﻿using System;
using System.Collections.Generic;

namespace diagoback.Models
{
    public partial class FailedJobs
    {
        public long Id { get; set; }
        public string Connection { get; set; }
        public string Queue { get; set; }
        public string Payload { get; set; }
        public string Exception { get; set; }
        public DateTimeOffset FailedAt { get; set; }
    }
}
