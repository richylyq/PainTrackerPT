using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PainTrackerPT.Models;
using PainTrackerPT.Models.Followups;

namespace PainTrackerPT.Controllers.Followups
{
    public class FollowupsLogsController : Controller
    {
        private readonly PainTrackerPTContext _context;

        public FollowupsLogsController(PainTrackerPTContext context)
        {
            _context = context;
        }

        // GET: FollowupsLogs
        public async Task<IActionResult> Index()
        {
            return View(await _context.FollowupsLog.ToListAsync());
        }

        // GET: FollowupsLogs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var followupsLog = await _context.FollowupsLog
                .FirstOrDefaultAsync(m => m.Id == id);
            if (followupsLog == null)
            {
                return NotFound();
            }

            return View(followupsLog);
        }

        // GET: FollowupsLogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FollowupsLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,timeStamp")] FollowupsLog followupsLog)
        {
            if (ModelState.IsValid)
            {
                followupsLog.Id = Guid.NewGuid();
                _context.Add(followupsLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(followupsLog);
        }

        // GET: FollowupsLogs/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var followupsLog = await _context.FollowupsLog.FindAsync(id);
            if (followupsLog == null)
            {
                return NotFound();
            }
            return View(followupsLog);
        }

        // POST: FollowupsLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Description,timeStamp")] FollowupsLog followupsLog)
        {
            if (id != followupsLog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(followupsLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FollowupsLogExists(followupsLog.Id))
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
            return View(followupsLog);
        }

        // GET: FollowupsLogs/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var followupsLog = await _context.FollowupsLog
                .FirstOrDefaultAsync(m => m.Id == id);
            if (followupsLog == null)
            {
                return NotFound();
            }

            return View(followupsLog);
        }

        // POST: FollowupsLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var followupsLog = await _context.FollowupsLog.FindAsync(id);
            _context.FollowupsLog.Remove(followupsLog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FollowupsLogExists(Guid id)
        {
            return _context.FollowupsLog.Any(e => e.Id == id);
        }
    }
}
