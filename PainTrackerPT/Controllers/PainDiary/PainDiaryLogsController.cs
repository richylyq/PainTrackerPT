﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PainTrackerPT.Data;
using PainTrackerPT.Models;
using PainTrackerPT.Models.PainDiary;

namespace PainTrackerPT.Controllers.PainDiary
{
    public class PainDiaryLogsController : Controller
    {
        private UnitOfWork uow = new UnitOfWork();
        PainTrackerPTContext pd = new PainTrackerPTContext();

        public List<Log> GetLogs()
        {
            List<Log> log = pd.Log.ToList();
            return log.ToList();
        }


        // GET: Entry
        public ActionResult EntryIndex()
        {
            var entry = uow.EntryRepository.Get();
            return View(entry.ToList());
        }

        // GET: Entry/Details/5
        public ActionResult EntryDetails(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Entry entry = uow.EntryRepository.GetByID(id);
            if (entry == null)
            {
                return NotFound();
            }
            return View(entry);
        }

        // GET: Entry/Create
        public ActionResult EntryCreate(int id)
        {
            return View(id);
        }

        // POST: Entry/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EntryCreate(Entry entry)
        {
            try
            {
                // Insert Logic here
                uow.EntryRepository.Insert(entry);
                uow.Save();
                return RedirectToAction(nameof(EntryDetails), new { id = entry.entryID });
            }
            catch
            {
                return View();
            }
        }

        // GET: Entry/Edit/5
        public ActionResult EntryEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Entry selected = new Entry();
            selected = uow.EntryRepository.GetByID(id);

            if (selected == null)
            {
                return NotFound();
            }
            return View(selected);
        }

        // POST: Entry/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EntryEdit(int id, [Bind("entryID,entryTitle,entryDescription,entryTime,painArea,painIntensity,painTime,diaryId")] Entry entry)
        {
            if (ModelState.IsValid)
            {
                // Update logic here
                uow.EntryRepository.Update(entry);
                uow.Save();
                return RedirectToAction(nameof(EntryIndex));
            }
            return View(entry);
        }

        // GET: Entry/Delete/5
        public ActionResult EntryDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Entry entry = uow.EntryRepository.GetByID(id);

            if (entry == null)
            {
                return NotFound();
            }

            return View(entry);
        }

        // POST: Entry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult EntryDelete(int id)
        {
            // Delete logic here
            Entry entry = uow.EntryRepository.GetByID(id);
            uow.EntryRepository.Delete(id);
            uow.Save();
            return RedirectToAction(nameof(EntryIndex));
        }

        public ActionResult EntryView(int id)
        {
            Entry selected = new Entry();
            selected = uow.EntryRepository.GetByID(id);
            ViewBag.logs = GetLogs();
            return View(selected);
        }
    }
}