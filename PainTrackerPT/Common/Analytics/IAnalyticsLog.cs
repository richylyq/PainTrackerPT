using PainTrackerPT.Models.Analytics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainTrackerPT.Common.Analytics
{
    interface IAnalyticsLog
    {
        AnalyticsLog GetLogAt(DateTime dt);
        AnalyticsLog GetLogFromTo(DateTime start_dt, DateTime end_dt);
    }
}
