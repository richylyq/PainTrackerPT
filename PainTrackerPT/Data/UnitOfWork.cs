using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PainTrackerPT.Models;
using PainTrackerPT.Models.PainDiary;

namespace PainTrackerPT.Data
{
    public class UnitOfWork
    {
        private PainTrackerPTContext context = new PainTrackerPTContext();
        private GenericRepository<Diary> diaryRepository;
        private GenericRepository<Entry> entryRepository;
        private GenericRepository<Log> logRepository;

        public GenericRepository<Diary> DiaryRepository
        {
            get
            {
                if (this.diaryRepository == null)
                {
                    this.diaryRepository = new GenericRepository<Diary>(context);
                }
                return diaryRepository;
            }
        }

        public GenericRepository<Entry> EntryRepository
        {
            get
            {
                if (this.entryRepository == null)
                {
                    this.entryRepository = new GenericRepository<Entry>(context);
                }
                return entryRepository;
            }
        }

        public GenericRepository<Log> LogRepository
        {
            get
            {
                if (this.logRepository == null)
                {
                    this.logRepository = new GenericRepository<Log>(context);
                }
                return logRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }


    }
}
