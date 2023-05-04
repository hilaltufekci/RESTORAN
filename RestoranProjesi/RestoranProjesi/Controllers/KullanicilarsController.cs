﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestoranProjesi.Models;

namespace RestoranProjesi.Controllers
{
    public class KullanicilarsController : Controller
    {
        private readonly RestoranContext _context;

        public KullanicilarsController(RestoranContext context)
        {
            _context = context;
        }

        // GET: Kullanicilars
        public async Task<IActionResult> Index()
        {
              return _context.Kullanicilars != null ? 
                          View(await _context.Kullanicilars.ToListAsync()) :
                          Problem("Entity set 'RestoranContext.Kullanicilars'  is null.");
        }

        // GET: Kullanicilars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Kullanicilars == null)
            {
                return NotFound();
            }

            var kullanicilar = await _context.Kullanicilars
                .FirstOrDefaultAsync(m => m.KullaniciNo == id);
            if (kullanicilar == null)
            {
                return NotFound();
            }

            return View(kullanicilar);
        }

        // GET: Kullanicilars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kullanicilars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KullaniciNo,KullaniciAdi,Sifre")] Kullanicilar kullanicilar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kullanicilar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kullanicilar);
        }

        // GET: Kullanicilars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Kullanicilars == null)
            {
                return NotFound();
            }

            var kullanicilar = await _context.Kullanicilars.FindAsync(id);
            if (kullanicilar == null)
            {
                return NotFound();
            }
            return View(kullanicilar);
        }

        // POST: Kullanicilars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KullaniciNo,KullaniciAdi,Sifre")] Kullanicilar kullanicilar)
        {
            if (id != kullanicilar.KullaniciNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kullanicilar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KullanicilarExists(kullanicilar.KullaniciNo))
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
            return View(kullanicilar);
        }

        // GET: Kullanicilars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Kullanicilars == null)
            {
                return NotFound();
            }

            var kullanicilar = await _context.Kullanicilars
                .FirstOrDefaultAsync(m => m.KullaniciNo == id);
            if (kullanicilar == null)
            {
                return NotFound();
            }

            return View(kullanicilar);
        }

        // POST: Kullanicilars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Kullanicilars == null)
            {
                return Problem("Entity set 'RestoranContext.Kullanicilars'  is null.");
            }
            var kullanicilar = await _context.Kullanicilars.FindAsync(id);
            if (kullanicilar != null)
            {
                _context.Kullanicilars.Remove(kullanicilar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KullanicilarExists(int id)
        {
          return (_context.Kullanicilars?.Any(e => e.KullaniciNo == id)).GetValueOrDefault();
        }
    }
}
