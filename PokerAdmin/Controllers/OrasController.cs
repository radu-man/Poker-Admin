using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PokerAdmin.Data;
using PokerAdmin.Models;

namespace PokerAdmin
{
    public class OrasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Oras
        public async Task<IActionResult> Index()
        {
              return _context.Oras != null ? 
                          View(await _context.Oras.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Oras'  is null.");
        }

        // GET: Oras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Oras == null)
            {
                return NotFound();
            }

            var oras = await _context.Oras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oras == null)
            {
                return NotFound();
            }

            return View(oras);
        }

        // GET: Oras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Oras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nume")] Oras oras)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oras);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oras);
        }

        // GET: Oras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Oras == null)
            {
                return NotFound();
            }

            var oras = await _context.Oras.FindAsync(id);
            if (oras == null)
            {
                return NotFound();
            }
            return View(oras);
        }

        // POST: Oras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nume")] Oras oras)
        {
            if (id != oras.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oras);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrasExists(oras.Id))
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
            return View(oras);
        }

        // GET: Oras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Oras == null)
            {
                return NotFound();
            }

            var oras = await _context.Oras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oras == null)
            {
                return NotFound();
            }

            return View(oras);
        }

        // POST: Oras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Oras == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Oras'  is null.");
            }
            var oras = await _context.Oras.FindAsync(id);
            if (oras != null)
            {
                _context.Oras.Remove(oras);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrasExists(int id)
        {
          return (_context.Oras?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
