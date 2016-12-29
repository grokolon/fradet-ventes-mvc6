using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionVentesMVC6.Data;
using GestionVentesMVC6.Models;

namespace GestionVentesMVC6.Controllers
{
    public class CompagniesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompagniesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Compagnies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Compagnie.ToListAsync());
        }

        // GET: Compagnies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compagnie = await _context.Compagnie.SingleOrDefaultAsync(m => m.ID == id);
            if (compagnie == null)
            {
                return NotFound();
            }

            return View(compagnie);
        }

        // GET: Compagnies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Compagnies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nom")] Compagnie compagnie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(compagnie);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(compagnie);
        }

        // GET: Compagnies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compagnie = await _context.Compagnie.SingleOrDefaultAsync(m => m.ID == id);
            if (compagnie == null)
            {
                return NotFound();
            }
            return View(compagnie);
        }

        // POST: Compagnies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nom")] Compagnie compagnie)
        {
            if (id != compagnie.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compagnie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompagnieExists(compagnie.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(compagnie);
        }

        // GET: Compagnies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compagnie = await _context.Compagnie.SingleOrDefaultAsync(m => m.ID == id);
            if (compagnie == null)
            {
                return NotFound();
            }

            return View(compagnie);
        }

        // POST: Compagnies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compagnie = await _context.Compagnie.SingleOrDefaultAsync(m => m.ID == id);
            _context.Compagnie.Remove(compagnie);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CompagnieExists(int id)
        {
            return _context.Compagnie.Any(e => e.ID == id);
        }
    }
}
