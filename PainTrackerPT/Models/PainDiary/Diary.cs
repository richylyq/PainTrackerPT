using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PainTrackerPT.Models.PainDiary
{
    [Table("Diary")]
    public class Diary
    {
        
        public int diaryID { get; set; }

        public String diaryTitle { get; set; }

        [DataType(DataType.Date)]
        public DateTime creationDate { get; set; }

        public Boolean diaryPermission { get; set; }

    }
}
