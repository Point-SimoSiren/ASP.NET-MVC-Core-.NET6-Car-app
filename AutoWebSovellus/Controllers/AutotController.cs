using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoWebSovellus.Models;

namespace AutoWebSovellus.Controllers
{
    public class AutotController : Controller
    {
        private readonly AutoDBContext _context = new AutoDBContext(); 


        // GET: Autot
   
        public async Task<ActionResult> Index([Bind("Merkki")] string searching)
        {
            return View(await _context.Autots.Where(x => x.Merkki.Contains(searching) || searching == null).ToListAsync());
        }

        // GET: Autot/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Autots == null)
            {
                return NotFound();
            }

            var autot = await _context.Autots
                .FirstOrDefaultAsync(m => m.AutoId == id);
            if (autot == null)
            {
                return NotFound();
            }

            return View(autot);
        }

        // GET: Autot/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Autot/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AutoId,Merkki,Malli,Vuosimalli,Rekisterinumero")] Autot autot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(autot);
        }

        // GET: Autot/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Autots == null)
            {
                return NotFound();
            }

            var autot = await _context.Autots.FindAsync(id);
            if (autot == null)
            {
                return NotFound();
            }
            return View(autot);
        }

        // POST: Autot/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AutoId,Merkki,Malli,Vuosimalli,Rekisterinumero")] Autot autot)
        {
            if (id != autot.AutoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutotExists(autot.AutoId))
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
            return View(autot);
        }

        // GET: Autot/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Autots == null)
            {
                return NotFound();
            }

            var autot = await _context.Autots
                .FirstOrDefaultAsync(m => m.AutoId == id);
            if (autot == null)
            {
                return NotFound();
            }

            return View(autot);
        }

        // POST: Autot/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Autots == null)
            {
                return Problem("Entity set 'AutoDBContext.Autots'  is null.");
            }
            var autot = await _context.Autots.FindAsync(id);
            if (autot != null)
            {
                _context.Autots.Remove(autot);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutotExists(int id)
        {
          return _context.Autots.Any(e => e.AutoId == id);
        }
    }
}
