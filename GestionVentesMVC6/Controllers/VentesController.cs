using GestionVentesMVC6.Data;
using GestionVentesMVC6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GestionVentesMVC6.Controllers
{
    public class VentesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VentesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Ventes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Vente.Include(v => v.Compagnie).Include(v => v.TypeAssurance).Include(v => v.TypePolice).Include(v => v.Vendeur);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Ventes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vente = await _context.Vente.SingleOrDefaultAsync(m => m.ID == id);
            if (vente == null)
            {
                return NotFound();
            }

            return View(vente);
        }

        // GET: Ventes/Create
        public IActionResult Create()
        {
            ViewData["CompagnieID"] = new SelectList(_context.Compagnie, "ID", "Nom");
            ViewData["TypeAssuranceID"] = new SelectList(_context.TypeAssurance, "ID", "Nom");
            ViewData["TypePoliceID"] = new SelectList(_context.TypePolice, "ID", "Nom");
            ViewData["VendeurID"] = new SelectList(_context.Vendeur, "ID", "Nom");
            return View();
        }

        // POST: Ventes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Client,CompagnieID,DateVente,MontantPrimeTotal,PourcentageCommission,Reference,TypeAssuranceID,TypePoliceID,VendeurID")] Vente vente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vente);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CompagnieID"] = new SelectList(_context.Compagnie, "ID", "ID", vente.CompagnieID);
            ViewData["TypeAssuranceID"] = new SelectList(_context.TypeAssurance, "ID", "Nom", vente.TypeAssuranceID);
            ViewData["TypePoliceID"] = new SelectList(_context.TypePolice, "ID", "Nom", vente.TypePoliceID);
            ViewData["VendeurID"] = new SelectList(_context.Vendeur, "ID", "ID", vente.VendeurID);
            return View(vente);
        }

        // GET: Ventes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vente = await _context.Vente.SingleOrDefaultAsync(m => m.ID == id);
            if (vente == null)
            {
                return NotFound();
            }
            ViewData["CompagnieID"] = new SelectList(_context.Compagnie, "ID", "Nom", vente.CompagnieID);
            ViewData["TypeAssuranceID"] = new SelectList(_context.TypeAssurance, "ID", "Nom", vente.TypeAssuranceID);
            ViewData["TypePoliceID"] = new SelectList(_context.TypePolice, "ID", "Nom", vente.TypePoliceID);
            ViewData["VendeurID"] = new SelectList(_context.Vendeur, "ID", "Nom", vente.VendeurID);
            return View(vente);
        }

        // POST: Ventes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Client,CompagnieID,DateVente,MontantPrimeTotal,PourcentageCommission,Reference,TypeAssuranceID,TypePoliceID,VendeurID")] Vente vente)
        {
            if (id != vente.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VenteExists(vente.ID))
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
            ViewData["CompagnieID"] = new SelectList(_context.Compagnie, "ID", "Nom", vente.CompagnieID);
            ViewData["TypeAssuranceID"] = new SelectList(_context.TypeAssurance, "ID", "Nom", vente.TypeAssuranceID);
            ViewData["TypePoliceID"] = new SelectList(_context.TypePolice, "ID", "Nom", vente.TypePoliceID);
            ViewData["VendeurID"] = new SelectList(_context.Vendeur, "ID", "Nom", vente.VendeurID);
            return View(vente);
        }

        // GET: Ventes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vente = await _context.Vente.SingleOrDefaultAsync(m => m.ID == id);
            if (vente == null)
            {
                return NotFound();
            }

            return View(vente);
        }

        // POST: Ventes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vente = await _context.Vente.SingleOrDefaultAsync(m => m.ID == id);
            _context.Vente.Remove(vente);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool VenteExists(int id)
        {
            return _context.Vente.Any(e => e.ID == id);
        }
    }
}
