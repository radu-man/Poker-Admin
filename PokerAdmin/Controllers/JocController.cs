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
    public class JocController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JocController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Joc
        public async Task<IActionResult> Index()
        {
              return _context.Joc != null ? 
                          View(await _context.Joc.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Joc'  is null.");
        }

        // GET: Joc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Joc == null)
            {
                return NotFound();
            }

            var joc = await _context.Joc
                .FirstOrDefaultAsync(m => m.Id == id);
            if (joc == null)
            {
                return NotFound();
            }

            return View(joc);
        }

        // GET: Joc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Joc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Denumire")] Joc joc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(joc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(joc);
        }

        // GET: Joc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Joc == null)
            {
                return NotFound();
            }

            var joc = await _context.Joc.FindAsync(id);
            if (joc == null)
            {
                return NotFound();
            }
            return View(joc);
        }

        // POST: Joc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Denumire")] Joc joc)
        {
            if (id != joc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(joc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JocExists(joc.Id))
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
            return View(joc);
        }

        // GET: Joc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Joc == null)
            {
                return NotFound();
            }

            var joc = await _context.Joc
                .FirstOrDefaultAsync(m => m.Id == id);
            if (joc == null)
            {
                return NotFound();
            }

            return View(joc);
        }

        // POST: Joc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Joc == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Joc'  is null.");
            }
            var joc = await _context.Joc.FindAsync(id);
            if (joc != null)
            {
                _context.Joc.Remove(joc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JocExists(int id)
        {
          return (_context.Joc?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
