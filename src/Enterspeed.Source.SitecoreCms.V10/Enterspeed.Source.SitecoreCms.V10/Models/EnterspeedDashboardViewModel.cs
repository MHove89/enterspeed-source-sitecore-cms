﻿using System.Collections.Generic;
using Enterspeed.Source.SitecoreCms.V10.Data.Models;

namespace Enterspeed.Source.SitecoreCms.V10.Models
{
    public class EnterspeedDashboardViewModel
    {
        public IList<EnterspeedJob> PendingJobs { get; set; }
        public IList<EnterspeedJob> FailedJobs { get; set; }
    }
}