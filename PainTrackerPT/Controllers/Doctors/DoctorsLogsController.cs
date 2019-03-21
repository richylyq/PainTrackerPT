using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PainTrackerPT.Models;
using PainTrackerPT.Models.Doctors;

namespace PainTrackerPT.Controllers.Doctors
{
    public class DoctorsLogsController : Controller
    {
        private readonly PainTrackerPTContext _context;

        public DoctorsLogsController(PainTrackerPTContext context)
        {
            _context = context;
        }

        // GET: DoctorsLogs
        public async Task<IActionResult> Index()
        {
            return View(await _context.DoctorsLog.ToListAsync());
        }

        // GET: DoctorsLogs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorsLog = await _context.DoctorsLog
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctorsLog == null)
            {
                return NotFound();
            }

            return View(doctorsLog);
        }

        // GET: DoctorsLogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DoctorsLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,timeStamp")] DoctorsLog doctorsLog)
        {
            if (ModelState.IsValid)
            {
                doctorsLog.Id = Guid.NewGuid();
                _context.Add(doctorsLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doctorsLog);
        }

        // GET: DoctorsLogs/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorsLog = await _context.DoctorsLog.FindAsync(id);
            if (doctorsLog == null)
            {
                return NotFound();
            }
            return View(doctorsLog);
        }

        // POST: DoctorsLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Description,timeStamp")] DoctorsLog doctorsLog)
        {
            if (id != doctorsLog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctorsLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorsLogExists(doctorsLog.Id))
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
            return View(doctorsLog);
        }

        // GET: DoctorsLogs/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorsLog = await _context.DoctorsLog
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctorsLog == null)
            {
                return NotFound();
            }

            return View(doctorsLog);
        }

        // POST: DoctorsLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var doctorsLog = await _context.DoctorsLog.FindAsync(id);
            _context.DoctorsLog.Remove(doctorsLog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorsLogExists(Guid id)
        {
            return _context.DoctorsLog.Any(e => e.Id == id);
        }
    }
}
