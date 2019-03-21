using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PainTrackerPT.Models;
using PainTrackerPT.Models.PainDiary;

namespace PainTrackerPT.Controllers.PainDiary
{
    public class PainDiaryLogsController : Controller
    {
        private readonly PainTrackerPTContext _context;

        public PainDiaryLogsController(PainTrackerPTContext context)
        {
            _context = context;
        }

        // GET: PainDiaryLogs
        public async Task<IActionResult> Index()
        {
            return View(await _context.PainDiaryLog.ToListAsync());
        }

        // GET: PainDiaryLogs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var painDiaryLog = await _context.PainDiaryLog
                .FirstOrDefaultAsync(m => m.Id == id);
            if (painDiaryLog == null)
            {
                return NotFound();
            }

            return View(painDiaryLog);
        }

        // GET: PainDiaryLogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PainDiaryLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,timeStamp")] PainDiaryLog painDiaryLog)
        {
            if (ModelState.IsValid)
            {
                painDiaryLog.Id = Guid.NewGuid();
                _context.Add(painDiaryLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(painDiaryLog);
        }

        // GET: PainDiaryLogs/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var painDiaryLog = await _context.PainDiaryLog.FindAsync(id);
            if (painDiaryLog == null)
            {
                return NotFound();
            }
            return View(painDiaryLog);
        }

        // POST: PainDiaryLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Description,timeStamp")] PainDiaryLog painDiaryLog)
        {
            if (id != painDiaryLog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(painDiaryLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PainDiaryLogExists(painDiaryLog.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(painDiaryLog);
        }

        // GET: PainDiaryLogs/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var painDiaryLog = await _context.PainDiaryLog
                .FirstOrDefaultAsync(m => m.Id == id);
            if (painDiaryLog == null)
            {
                return NotFound();
            }

            return View(painDiaryLog);
        }

        // POST: PainDiaryLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var painDiaryLog = await _context.PainDiaryLog.FindAsync(id);
            _context.PainDiaryLog.Remove(painDiaryLog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PainDiaryLogExists(Guid id)
        {
            return _context.PainDiaryLog.Any(e => e.Id == id);
        }
    }
}
