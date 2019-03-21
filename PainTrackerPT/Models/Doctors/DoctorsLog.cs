using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainTrackerPT.Models.Doctors
{
    public class DoctorsLog
    {
        public Guid Id { get; set; }
        public String Description { get; set; }
        public DateTime timeStamp { get; set; }
    }
}
