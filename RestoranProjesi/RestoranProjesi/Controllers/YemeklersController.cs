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
    public class YemeklersController : Controller
    {
        private readonly RestoranContext _context;

        public YemeklersController(RestoranContext context)
        {
            _context = context;
        }

        // GET: Yemeklers
        public async Task<IActionResult> Index()
        {
              return _context.Yemeklers != null ? 
                          View(await _context.Yemeklers.ToListAsync()) :
                          Problem("Entity set 'RestoranContext.Yemeklers'  is null.");
        }

        // GET: Yemeklers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Yemeklers == null)
            {
                return NotFound();
            }

            var yemekler = await _context.Yemeklers
                .FirstOrDefaultAsync(m => m.YemekNo == id);
            if (yemekler == null)
            {
                return NotFound();
            }

            return View(yemekler);
        }

        // GET: Yemeklers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Yemeklers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("YemekNo,YemekAdi,Fiyat,Porsiyon,ŞefAdi")] Yemekler yemekler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yemekler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yemekler);
        }

        // GET: Yemeklers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Yemeklers == null)
            {
                return NotFound();
            }

            var yemekler = await _context.Yemeklers.FindAsync(id);
            if (yemekler == null)
            {
                return NotFound();
            }
            return View(yemekler);
        }

        // POST: Yemeklers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("YemekNo,YemekAdi,Fiyat,Porsiyon,ŞefAdi")] Yemekler yemekler)
        {
            if (id != yemekler.YemekNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yemekler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YemeklerExists(yemekler.YemekNo))
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
            return View(yemekler);
        }

        // GET: Yemeklers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Yemeklers == null)
            {
                return NotFound();
            }

            var yemekler = await _context.Yemeklers
                .FirstOrDefaultAsync(m => m.YemekNo == id);
            if (yemekler == null)
            {
                return NotFound();
            }

            return View(yemekler);
        }

        // POST: Yemeklers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Yemeklers == null)
            {
                return Problem("Entity set 'RestoranContext.Yemeklers'  is null.");
            }
            var yemekler = await _context.Yemeklers.FindAsync(id);
            if (yemekler != null)
            {
                _context.Yemeklers.Remove(yemekler);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YemeklerExists(int id)
        {
          return (_context.Yemeklers?.Any(e => e.YemekNo == id)).GetValueOrDefault();
        }
    }
}
