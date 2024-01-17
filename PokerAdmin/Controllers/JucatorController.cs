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
    public class JucatorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JucatorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Jucator
        public async Task<IActionResult> Index()
        {
              return _context.Jucator != null ? 
                          View(await _context.Jucator.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Jucator'  is null.");
        }

        // GET: Jucator/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Jucator == null)
            {
                return NotFound();
            }

            var jucator = await _context.Jucator
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jucator == null)
            {
                return NotFound();
            }

            return View(jucator);
        }

        // GET: Jucator/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jucator/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nume,Prenume,Porecla")] Jucator jucator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jucator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jucator);
        }

        // GET: Jucator/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Jucator == null)
            {
                return NotFound();
            }

            var jucator = await _context.Jucator.FindAsync(id);
            if (jucator == null)
            {
                return NotFound();
            }
            return View(jucator);
        }

        // POST: Jucator/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nume,Prenume,Porecla")] Jucator jucator)
        {
            if (id != jucator.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jucator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JucatorExists(jucator.Id))
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
            return View(jucator);
        }

        // GET: Jucator/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Jucator == null)
            {
                return NotFound();
            }

            var jucator = await _context.Jucator
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jucator == null)
            {
                return NotFound();
            }

            return View(jucator);
        }

        // POST: Jucator/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Jucator == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Jucator'  is null.");
            }
            var jucator = await _context.Jucator.FindAsync(id);
            if (jucator != null)
            {
                _context.Jucator.Remove(jucator);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JucatorExists(int id)
        {
          return (_context.Jucator?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
