using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PainTrackerPT.Models.Analytics;
using PainTrackerPT.Models.Doctors;
using PainTrackerPT.Models.Events;
using PainTrackerPT.Models.Followups;
using PainTrackerPT.Models.Medicine;
using PainTrackerPT.Models.PainDiary;

namespace PainTrackerPT.Models
{
    public class PainTrackerPTContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PainDiary;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        public PainTrackerPTContext()
        {
        }

        public PainTrackerPTContext (DbContextOptions<PainTrackerPTContext> options)
            : base(options)
        {
        }

        public DbSet<PainTrackerPT.Models.Analytics.AnalyticsLog> AnalyticsLog { get; set; }

        public DbSet<PainTrackerPT.Models.Doctors.DoctorsLog> DoctorsLog { get; set; }

        public DbSet<PainTrackerPT.Models.Events.EventsLog> EventsLog { get; set; }

        public DbSet<PainTrackerPT.Models.Followups.FollowupsLog> FollowupsLog { get; set; }

        public DbSet<PainTrackerPT.Models.Medicine.MedicineLog> MedicineLog { get; set; }

        public DbSet<PainTrackerPT.Models.PainDiary.PainDiaryLog> PainDiaryLog { get; set; }

        public DbSet<PainTrackerPT.Models.PainDiary.Diary> Diary { get; set; }
        public new DbSet<PainTrackerPT.Models.PainDiary.Entry> Entry { get; set; }
        public DbSet<PainTrackerPT.Models.PainDiary.Log> Log { get; set; }
    }
}
