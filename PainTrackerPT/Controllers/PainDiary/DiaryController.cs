using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PainTrackerPT.Models;
using PainTrackerPT.Data;
using PainTrackerPT.Models.PainDiary;

namespace PainTrackerPT.Controllers.PainDiary
{
    public class DiaryController : Controller
    {
        private UnitOfWork uow = new UnitOfWork();

        

        // GET: Diary
        public ActionResult Index()
        {
            var diary = uow.DiaryRepository.Get();
            return View(diary.ToList());
        }

        // GET: Diary/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Diary diary = uow.DiaryRepository.GetByID(id);
            if (diary == null)
            {
                return NotFound();
            }

            return View(diary);
        }

        // GET: Diary/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Diary/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Diary diary)
        {
            try
            {
                // Insert logic here
                uow.DiaryRepository.Insert(diary);
                uow.Save();
                return RedirectToAction(nameof(Details), new { id = diary.diaryID });
            }
            catch
            {
                return View();
            }
        }

        // GET: Diary/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Diary selected = uow.DiaryRepository.GetByID(id);
            
            if (selected == null)
            {
                return NotFound();
            }
            return View(selected);
        }

        // POST: Diary/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("diaryID,diaryPermission")] Diary diary)
        {
            if (ModelState.IsValid)
            {
                // Update logic here
                uow.DiaryRepository.Update(diary);
                uow.Save();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Diary/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Diary diary = uow.DiaryRepository.GetByID(id);
            if (diary == null)
            {
                return NotFound();
            }

            return View(diary);
        }

        // POST: Diary/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            // Delete logic here
            uow.DiaryRepository.Delete(id);
            uow.Save();
            return RedirectToAction(nameof(Index));
        }


        public ActionResult View(int id)
        {
            Diary selected = new Diary();
            selected = uow.DiaryRepository.GetByID(id);
            return View(selected);
        }

  


    }
}
