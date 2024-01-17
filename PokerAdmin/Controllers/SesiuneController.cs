using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PokerAdmin.Data;
using PokerAdmin.Models;

namespace PokerAdmin.Controllers
{
    public class SesiuneController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SesiuneController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sesiune
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Sesiune.Include(s => s.Jucator);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Sesiune/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sesiune == null)
            {
                return NotFound();
            }

            var sesiune = await _context.Sesiune
                .Include(s => s.Jucator)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sesiune == null)
            {
                return NotFound();
            }

            return View(sesiune);
        }

        // GET: Sesiune/Create
        public IActionResult Create()
        {
            ViewData["JucatorId"] = new SelectList(_context.Jucator, "Id", "Id");
            return View();
        }

        // POST: Sesiune/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrasId,ClubId,JocId,JucatorId")] Sesiune sesiune)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sesiune);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JucatorId"] = new SelectList(_context.Jucator, "Id", "Id", sesiune.JucatorId);
            return View(sesiune);
        }

        // GET: Sesiune/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sesiune == null)
            {
                return NotFound();
            }

            var sesiune = await _context.Sesiune.FindAsync(id);
            if (sesiune == null)
            {
                return NotFound();
            }
            ViewData["JucatorId"] = new SelectList(_context.Jucator, "Id", "Id", sesiune.JucatorId);
            return View(sesiune);
        }

        // POST: Sesiune/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrasId,ClubId,JocId,JucatorId")] Sesiune sesiune)
        {
            if (id != sesiune.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sesiune);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SesiuneExists(sesiune.Id))
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
            ViewData["JucatorId"] = new SelectList(_context.Jucator, "Id", "Id", sesiune.JucatorId);
            return View(sesiune);
        }

        // GET: Sesiune/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sesiune == null)
            {
                return NotFound();
            }

            var sesiune = await _context.Sesiune
                .Include(s => s.Jucator)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sesiune == null)
            {
                return NotFound();
            }

            return View(sesiune);
        }

        // POST: Sesiune/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sesiune == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Sesiune'  is null.");
            }
            var sesiune = await _context.Sesiune.FindAsync(id);
            if (sesiune != null)
            {
                _context.Sesiune.Remove(sesiune);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SesiuneExists(int id)
        {
          return (_context.Sesiune?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
