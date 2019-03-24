using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PainTrackerPT.Models.PainDiary
{
    [Table("Entry")]
    public class Entry
    {
        [Display(Name ="Entry ID")]
        public int entryID { get; set; }

        [Display(Name = "Entry Title")]
        public String entryTitle { get; set; }

        [Display(Name = "Entry Description")]
        public String entryDescription { get; set; }

        [Display(Name = "Entry Time")]
        [DataType(DataType.Date)]
        public DateTime entryTime { get; set; }

        [Display(Name = "Pain Area")]
        public String painArea { get; set; }

        [Display(Name ="Pain Intensity")]
        [Range(1,10)]
        public String painIntensity { get; set; }

        [Display(Name = "Pain Time")]
        public DateTime painTime { get; set; }

        [ForeignKey("Diary")]
        public int diaryId { get; set; }
        
    }
}
