using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PainTrackerPT.Models;
using PainTrackerPT.Models.Analytics;

namespace PainTrackerPT.Controllers
{
    public class AnalyticsLogsController : Controller
    {
        private readonly PainTrackerPTContext _context;

        public AnalyticsLogsController(PainTrackerPTContext context)
        {
            _context = context;
        }

        // GET: AnalyticsLogs
        public async Task<IActionResult> Index()
        {
            return View(await _context.AnalyticsLog.ToListAsync());
        }

        // GET: AnalyticsLogs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var analyticsLog = await _context.AnalyticsLog
                .FirstOrDefaultAsync(m => m.Id == id);
            if (analyticsLog == null)
            {
                return NotFound();
            }

            return View(analyticsLog);
        }

        // GET: AnalyticsLogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AnalyticsLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,timeStamp")] AnalyticsLog analyticsLog)
        {
            if (ModelState.IsValid)
            {
                analyticsLog.Id = Guid.NewGuid();
                _context.Add(analyticsLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(analyticsLog);
        }

        // GET: AnalyticsLogs/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var analyticsLog = await _context.AnalyticsLog.FindAsync(id);
            if (analyticsLog == null)
            {
                return NotFound();
            }
            return View(analyticsLog);
        }

        // POST: AnalyticsLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Description,timeStamp")] AnalyticsLog analyticsLog)
        {
            if (id != analyticsLog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(analyticsLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnalyticsLogExists(analyticsLog.Id))
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
            return View(analyticsLog);
        }

        // GET: AnalyticsLogs/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var analyticsLog = await _context.AnalyticsLog
                .FirstOrDefaultAsync(m => m.Id == id);
            if (analyticsLog == null)
            {
                return NotFound();
            }

            return View(analyticsLog);
        }

        // POST: AnalyticsLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var analyticsLog = await _context.AnalyticsLog.FindAsync(id);
            _context.AnalyticsLog.Remove(analyticsLog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnalyticsLogExists(Guid id)
        {
            return _context.AnalyticsLog.Any(e => e.Id == id);
        }
    }
}
