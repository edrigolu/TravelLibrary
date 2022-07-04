using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TravelLibrary.App.Entities;

namespace TravelLibrary.App.Controllers
{
    public class AutorLibrosController : Controller
    {
        private readonly TravelLibraryDbContext _context;

        public AutorLibrosController(TravelLibraryDbContext context)
        {
            _context = context;
        }

        // GET: AutorLibros
        public async Task<IActionResult> Index()
        {
            var travelLibraryDbContext = _context.AutorLibros.Include(a => a.Autores).Include(a => a.Libros);
            return View(await travelLibraryDbContext.ToListAsync());
        }

        // GET: AutorLibros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autorLibro = await _context.AutorLibros
                .Include(a => a.Autores)
                .Include(a => a.Libros)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autorLibro == null)
            {
                return NotFound();
            }

            return View(autorLibro);
        }

        // GET: AutorLibros/Create
        public IActionResult Create()
        {
            ViewData["AutoresId"] = new SelectList(_context.Autors, "Id", "Apellido");
            ViewData["LibrosId"] = new SelectList(_context.Libros, "Id", "Titulo");
            return View();
        }

        // POST: AutorLibros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AutoresId,LibrosId")] AutorLibro autorLibro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autorLibro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutoresId"] = new SelectList(_context.Autors, "Id", "Apellido", autorLibro.AutoresId);
            ViewData["LibrosId"] = new SelectList(_context.Libros, "Id", "Titulo", autorLibro.LibrosId);
            return View(autorLibro);
        }

        // GET: AutorLibros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autorLibro = await _context.AutorLibros.FindAsync(id);
            if (autorLibro == null)
            {
                return NotFound();
            }
            ViewData["AutoresId"] = new SelectList(_context.Autors, "Id", "Apellido", autorLibro.AutoresId);
            ViewData["LibrosId"] = new SelectList(_context.Libros, "Id", "Titulo", autorLibro.LibrosId);
            return View(autorLibro);
        }

        // POST: AutorLibros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AutoresId,LibrosId")] AutorLibro autorLibro)
        {
            if (id != autorLibro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autorLibro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutorLibroExists(autorLibro.Id))
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
            ViewData["AutoresId"] = new SelectList(_context.Autors, "Id", "Apellido", autorLibro.AutoresId);
            ViewData["LibrosId"] = new SelectList(_context.Libros, "Id", "Titulo", autorLibro.LibrosId);
            return View(autorLibro);
        }

        // GET: AutorLibros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AutorLibro autorLibro = await _context.AutorLibros
                .Include(a => a.Autores)
                .Include(a => a.Libros)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autorLibro == null)
            {
                return NotFound();
            }
            _context.AutorLibros.Remove(autorLibro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));            
        }

        // POST: AutorLibros/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var autorLibro = await _context.AutorLibros.FindAsync(id);
        //    _context.AutorLibros.Remove(autorLibro);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool AutorLibroExists(int id)
        {
            return _context.AutorLibros.Any(e => e.Id == id);
        }
    }
}
