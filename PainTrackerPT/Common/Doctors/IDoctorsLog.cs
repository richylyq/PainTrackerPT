using PainTrackerPT.Models.Doctors;
using PainTrackerPT.Models.PainDiary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainTrackerPT.Common.Doctors
{
    interface IDoctorsLog
    {
        DoctorsLog GetLogAt(DateTime dt);
        DoctorsLog GetLogFromTo(DateTime start_dt, DateTime end_dt);
    }
}
