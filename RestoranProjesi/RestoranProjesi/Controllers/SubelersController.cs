using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestoranProjesi.Models;

namespace RestoranProjesi.Controllers
{
    public class SubelersController : Controller
    {
        private readonly RestoranContext _context;

        public SubelersController(RestoranContext context)
        {
            _context = context;
        }

        // GET: Subelers
        public async Task<IActionResult> Index()
        {
              return _context.Subelers != null ? 
                          View(await _context.Subelers.ToListAsync()) :
                          Problem("Entity set 'RestoranContext.Subelers'  is null.");
        }

        // GET: Subelers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Subelers == null)
            {
                return NotFound();
            }

            var subeler = await _context.Subelers
                .FirstOrDefaultAsync(m => m.SubeNo == id);
            if (subeler == null)
            {
                return NotFound();
            }

            return View(subeler);
        }

        // GET: Subelers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Subelers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubeNo,SubeAdi,Il,Ilce")] Subeler subeler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subeler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subeler);
        }

        // GET: Subelers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Subelers == null)
            {
                return NotFound();
            }

            var subeler = await _context.Subelers.FindAsync(id);
            if (subeler == null)
            {
                return NotFound();
            }
            return View(subeler);
        }

        // POST: Subelers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubeNo,SubeAdi,Il,Ilce")] Subeler subeler)
        {
            if (id != subeler.SubeNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subeler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubelerExists(subeler.SubeNo))
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
            return View(subeler);
        }

        // GET: Subelers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Subelers == null)
            {
                return NotFound();
            }

            var subeler = await _context.Subelers
                .FirstOrDefaultAsync(m => m.SubeNo == id);
            if (subeler == null)
            {
                return NotFound();
            }

            return View(subeler);
        }

        // POST: Subelers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Subelers == null)
            {
                return Problem("Entity set 'RestoranContext.Subelers'  is null.");
            }
            var subeler = await _context.Subelers.FindAsync(id);
            if (subeler != null)
            {
                _context.Subelers.Remove(subeler);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubelerExists(int id)
        {
          return (_context.Subelers?.Any(e => e.SubeNo == id)).GetValueOrDefault();
        }
    }
}
