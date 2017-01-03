using GestionVentesMVC6.Data;
using GestionVentesMVC6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GestionVentesMVC6.Controllers
{
    public class TypesPoliceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TypesPoliceController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: TypesPolice
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypePolice.ToListAsync());
        }

        // GET: TypesPolice/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typePolice = await _context.TypePolice.SingleOrDefaultAsync(m => m.ID == id);
            if (typePolice == null)
            {
                return NotFound();
            }

            return View(typePolice);
        }

        // GET: TypesPolice/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypesPolice/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nom")] TypePolice typePolice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typePolice);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(typePolice);
        }

        // GET: TypesPolice/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typePolice = await _context.TypePolice.SingleOrDefaultAsync(m => m.ID == id);
            if (typePolice == null)
            {
                return NotFound();
            }
            return View(typePolice);
        }

        // POST: TypesPolice/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nom")] TypePolice typePolice)
        {
            if (id != typePolice.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typePolice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypePoliceExists(typePolice.ID))
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
            return View(typePolice);
        }

        // GET: TypesPolice/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typePolice = await _context.TypePolice.SingleOrDefaultAsync(m => m.ID == id);
            if (typePolice == null)
            {
                return NotFound();
            }

            return View(typePolice);
        }

        // POST: TypesPolice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typePolice = await _context.TypePolice.SingleOrDefaultAsync(m => m.ID == id);
            _context.TypePolice.Remove(typePolice);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TypePoliceExists(int id)
        {
            return _context.TypePolice.Any(e => e.ID == id);
        }
    }
}
