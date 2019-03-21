using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PainTrackerPT.Models;
using PainTrackerPT.Models.Medicine;

namespace PainTrackerPT.Controllers.Medicine
{
    public class MedicineLogsController : Controller
    {
        private readonly PainTrackerPTContext _context;

        public MedicineLogsController(PainTrackerPTContext context)
        {
            _context = context;
        }

        // GET: MedicineLogs
        public async Task<IActionResult> Index()
        {
            return View(await _context.MedicineLog.ToListAsync());
        }

        // GET: MedicineLogs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicineLog = await _context.MedicineLog
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicineLog == null)
            {
                return NotFound();
            }

            return View(medicineLog);
        }

        // GET: MedicineLogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MedicineLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,timeStamp")] MedicineLog medicineLog)
        {
            if (ModelState.IsValid)
            {
                medicineLog.Id = Guid.NewGuid();
                _context.Add(medicineLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicineLog);
        }

        // GET: MedicineLogs/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicineLog = await _context.MedicineLog.FindAsync(id);
            if (medicineLog == null)
            {
                return NotFound();
            }
            return View(medicineLog);
        }

        // POST: MedicineLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Description,timeStamp")] MedicineLog medicineLog)
        {
            if (id != medicineLog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicineLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicineLogExists(medicineLog.Id))
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
            return View(medicineLog);
        }

        // GET: MedicineLogs/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicineLog = await _context.MedicineLog
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicineLog == null)
            {
                return NotFound();
            }

            return View(medicineLog);
        }

        // POST: MedicineLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var medicineLog = await _context.MedicineLog.FindAsync(id);
            _context.MedicineLog.Remove(medicineLog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicineLogExists(Guid id)
        {
            return _context.MedicineLog.Any(e => e.Id == id);
        }
    }
}
