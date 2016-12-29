using GestionVentesMVC6.Data;
using GestionVentesMVC6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GestionVentesMVC6.Controllers
{
    public class VendeursController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VendeursController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Vendeurs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vendeur.ToListAsync());
        }

        // GET: Vendeurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendeur = await _context.Vendeur.SingleOrDefaultAsync(m => m.ID == id);
            if (vendeur == null)
            {
                return NotFound();
            }

            return View(vendeur);
        }

        // GET: Vendeurs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vendeurs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Actif,Nom")] Vendeur vendeur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vendeur);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(vendeur);
        }

        // GET: Vendeurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendeur = await _context.Vendeur.SingleOrDefaultAsync(m => m.ID == id);
            if (vendeur == null)
            {
                return NotFound();
            }
            return View(vendeur);
        }

        // POST: Vendeurs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Actif,Nom")] Vendeur vendeur)
        {
            if (id != vendeur.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendeur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendeurExists(vendeur.ID))
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
            return View(vendeur);
        }

        // GET: Vendeurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendeur = await _context.Vendeur.SingleOrDefaultAsync(m => m.ID == id);
            if (vendeur == null)
            {
                return NotFound();
            }

            return View(vendeur);
        }

        // POST: Vendeurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vendeur = await _context.Vendeur.SingleOrDefaultAsync(m => m.ID == id);
            _context.Vendeur.Remove(vendeur);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool VendeurExists(int id)
        {
            return _context.Vendeur.Any(e => e.ID == id);
        }
    }
}
