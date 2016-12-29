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
    public class TypesAssuranceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TypesAssuranceController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: TypesAssurance
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypeAssurance.ToListAsync());
        }

        // GET: TypesAssurance/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeAssurance = await _context.TypeAssurance.SingleOrDefaultAsync(m => m.ID == id);
            if (typeAssurance == null)
            {
                return NotFound();
            }

            return View(typeAssurance);
        }

        // GET: TypesAssurance/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypesAssurance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nom,PourcentageCommissionParDefaut")] TypeAssurance typeAssurance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeAssurance);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(typeAssurance);
        }

        // GET: TypesAssurance/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeAssurance = await _context.TypeAssurance.SingleOrDefaultAsync(m => m.ID == id);
            if (typeAssurance == null)
            {
                return NotFound();
            }
            return View(typeAssurance);
        }

        // POST: TypesAssurance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nom,PourcentageCommissionParDefaut")] TypeAssurance typeAssurance)
        {
            if (id != typeAssurance.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeAssurance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeAssuranceExists(typeAssurance.ID))
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
            return View(typeAssurance);
        }

        // GET: TypesAssurance/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeAssurance = await _context.TypeAssurance.SingleOrDefaultAsync(m => m.ID == id);
            if (typeAssurance == null)
            {
                return NotFound();
            }

            return View(typeAssurance);
        }

        // POST: TypesAssurance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeAssurance = await _context.TypeAssurance.SingleOrDefaultAsync(m => m.ID == id);
            _context.TypeAssurance.Remove(typeAssurance);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TypeAssuranceExists(int id)
        {
            return _context.TypeAssurance.Any(e => e.ID == id);
        }
    }
}
