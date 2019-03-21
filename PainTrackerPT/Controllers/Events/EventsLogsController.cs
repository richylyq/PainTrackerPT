using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PainTrackerPT.Models;
using PainTrackerPT.Models.Events;

namespace PainTrackerPT.Controllers.Events
{
    public class EventsLogsController : Controller
    {
        private readonly PainTrackerPTContext _context;

        public EventsLogsController(PainTrackerPTContext context)
        {
            _context = context;
        }

        // GET: EventsLogs
        public async Task<IActionResult> Index()
        {
            return View(await _context.EventsLog.ToListAsync());
        }

        // GET: EventsLogs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventsLog = await _context.EventsLog
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventsLog == null)
            {
                return NotFound();
            }

            return View(eventsLog);
        }

        // GET: EventsLogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EventsLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,timeStamp")] EventsLog eventsLog)
        {
            if (ModelState.IsValid)
            {
                eventsLog.Id = Guid.NewGuid();
                _context.Add(eventsLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventsLog);
        }

        // GET: EventsLogs/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventsLog = await _context.EventsLog.FindAsync(id);
            if (eventsLog == null)
            {
                return NotFound();
            }
            return View(eventsLog);
        }

        // POST: EventsLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Description,timeStamp")] EventsLog eventsLog)
        {
            if (id != eventsLog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventsLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventsLogExists(eventsLog.Id))
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
            return View(eventsLog);
        }

        // GET: EventsLogs/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventsLog = await _context.EventsLog
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventsLog == null)
            {
                return NotFound();
            }

            return View(eventsLog);
        }

        // POST: EventsLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var eventsLog = await _context.EventsLog.FindAsync(id);
            _context.EventsLog.Remove(eventsLog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventsLogExists(Guid id)
        {
            return _context.EventsLog.Any(e => e.Id == id);
        }
    }
}
