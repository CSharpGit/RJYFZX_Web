using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SofeDC.Models;
using SoftDC.Data;

namespace SofeDC.Areas.Adm.Controllers
{
    [Area("Adm")]
    public class NoticesController : Controller
    {
        private readonly RjyfzxDbContext _context;

        public NoticesController(RjyfzxDbContext context)
        {
            _context = context;
        }

        // GET: Adm/Notices
        public async Task<IActionResult> Index()
        {
            return View(await _context.Notices.ToListAsync());
        }

        // GET: Adm/Notices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notice = await _context.Notices
                .SingleOrDefaultAsync(m => m.ID == id);
            if (notice == null)
            {
                return NotFound();
            }

            return View(notice);
        }

        // GET: Adm/Notices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Adm/Notices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,ContentUrl,AnnouncedUser,AnnouncedDate")] Notice notice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(notice);
        }

        // GET: Adm/Notices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notice = await _context.Notices.SingleOrDefaultAsync(m => m.ID == id);
            if (notice == null)
            {
                return NotFound();
            }
            return View(notice);
        }

        // POST: Adm/Notices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,ContentUrl,AnnouncedUser,AnnouncedDate")] Notice notice)
        {
            if (id != notice.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoticeExists(notice.ID))
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
            return View(notice);
        }

        // GET: Adm/Notices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notice = await _context.Notices
                .SingleOrDefaultAsync(m => m.ID == id);
            if (notice == null)
            {
                return NotFound();
            }

            return View(notice);
        }

        // POST: Adm/Notices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var notice = await _context.Notices.SingleOrDefaultAsync(m => m.ID == id);
            _context.Notices.Remove(notice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoticeExists(int id)
        {
            return _context.Notices.Any(e => e.ID == id);
        }
    }
}
