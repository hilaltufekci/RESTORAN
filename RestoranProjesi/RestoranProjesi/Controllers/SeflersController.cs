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
    public class SeflersController : Controller
    {
        private readonly RestoranContext _context;

        public SeflersController(RestoranContext context)
        {
            _context = context;
        }

        // GET: Seflers
        public async Task<IActionResult> Index()
        {
              return _context.Seflers != null ? 
                          View(await _context.Seflers.ToListAsync()) :
                          Problem("Entity set 'RestoranContext.Seflers'  is null.");
        }

        // GET: Seflers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Seflers == null)
            {
                return NotFound();
            }

            var sefler = await _context.Seflers
                .FirstOrDefaultAsync(m => m.ŞefNo == id);
            if (sefler == null)
            {
                return NotFound();
            }

            return View(sefler);
        }

        // GET: Seflers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Seflers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ŞefNo,ŞefAdi,ŞefSoyad,Yas")] Sefler sefler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sefler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sefler);
        }

        // GET: Seflers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Seflers == null)
            {
                return NotFound();
            }

            var sefler = await _context.Seflers.FindAsync(id);
            if (sefler == null)
            {
                return NotFound();
            }
            return View(sefler);
        }

        // POST: Seflers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ŞefNo,ŞefAdi,ŞefSoyad,Yas")] Sefler sefler)
        {
            if (id != sefler.ŞefNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sefler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeflerExists(sefler.ŞefNo))
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
            return View(sefler);
        }

        // GET: Seflers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Seflers == null)
            {
                return NotFound();
            }

            var sefler = await _context.Seflers
                .FirstOrDefaultAsync(m => m.ŞefNo == id);
            if (sefler == null)
            {
                return NotFound();
            }

            return View(sefler);
        }

        // POST: Seflers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Seflers == null)
            {
                return Problem("Entity set 'RestoranContext.Seflers'  is null.");
            }
            var sefler = await _context.Seflers.FindAsync(id);
            if (sefler != null)
            {
                _context.Seflers.Remove(sefler);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeflerExists(int id)
        {
          return (_context.Seflers?.Any(e => e.ŞefNo == id)).GetValueOrDefault();
        }
    }
}
