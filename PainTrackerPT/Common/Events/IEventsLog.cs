using PainTrackerPT.Models.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainTrackerPT.Common.Events
{
    interface IEventsLog
    {
        EventsLog GetLogAt(DateTime dt);
        EventsLog GetLogFromTo(DateTime start_dt, DateTime end_dt);

    }
}
