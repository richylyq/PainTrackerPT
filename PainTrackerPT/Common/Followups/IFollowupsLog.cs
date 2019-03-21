using PainTrackerPT.Models.Followups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainTrackerPT.Common.Followups
{
    interface IFollowupssLog
    {
        FollowupsLog GetLogAt(DateTime dt);
        FollowupsLog GetLogFromTo(DateTime start_dt, DateTime end_dt);
    }
}
