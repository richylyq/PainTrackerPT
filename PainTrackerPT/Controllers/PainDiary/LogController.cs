using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PainTrackerPT.Models;
using PainTrackerPT.Models.PainDiary;
using PainTrackerPT.Data;

namespace PainTrackerPT.Controllers.PainDiary
{
    public class LogController : Controller
    {
        private UnitOfWork uow = new UnitOfWork();

                // GET: Log/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Log log = uow.LogRepository.GetByID(id);
            if (log == null)
            {
                return NotFound();
            }

            return View(log);
        }

        // GET: Log/Create
        public ActionResult Create(int id)
        {
            return View(id);
        }

        // POST: Log/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Log log)
        {
            try
            {
                // Insert Logic here
                uow.LogRepository.Insert(log);
                uow.Save();
                return RedirectToAction(nameof(Details), new { id = log.logID });
            } 
            catch
            {
                return View();
            }
            
        }

        // GET: Log/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Log selected = new Log();
            selected = uow.LogRepository.GetByID(id);
            if (selected == null)
            {
                return NotFound();
            }
            return View(selected);
        }

        // POST: Log/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("logID,logTime,writtenNotes,audioNotes,mood,entryId")] Log log)
        {
            if (ModelState.IsValid)
            {
                // Update logic here
                uow.LogRepository.Update(log);
                uow.Save();
                
            }
            return View(log);
        }

        // GET: Log/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Log log = uow.LogRepository.GetByID(id);
            if (log == null)
            {
                return NotFound();
            }

            return View(log);
        }

        // POST: Log/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            // Delete logic here
            uow.LogRepository.Delete(id);
            uow.Save();
            return RedirectToAction("Entry/Index");
        }

        
    }
}
