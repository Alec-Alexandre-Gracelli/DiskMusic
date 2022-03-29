using DiskMusic.Data;
using DiskMusic.Models;
using DiskMusic.ViewModel;
using ImobAdmin.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DiskMusic.Controllers
{
    public class MusicasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MusicasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Musicas
        public async Task<IActionResult> Index()
        {
            var musicas = await _context.Musicas.Include(a => a.Album).ToListAsync();
            return View(musicas);
        }

        // GET: Musicas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musica = await _context.Musicas
                .Select(s => new DetailsViewModel
                {
                    AlbumNome = s.Album.AlbumNome,
                    MusicaNome = s.MusicaNome,
                    MusicaId = s.MusicaId
                })
                .FirstOrDefaultAsync(m => m.MusicaId == id);

            if (musica == null)
            {
                return NotFound();
            }
            return View(musica);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Album = new SelectList(await DropDown.RetornaAlbuns(_context), "ID", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Musica musica)
        {
            if (ModelState.IsValid)
            {
                musica.MusicaId = Guid.NewGuid();
                _context.Musicas.Add(musica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(musica);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musica = await _context.Musicas.FindAsync(id);
            if (musica == null)
            {
                return NotFound();
            }
            ViewBag.Album = new SelectList(await DropDown.RetornaAlbuns(_context), "ID", "Nome");

            return View(musica);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Musica musica)
        {
            if (id != musica.MusicaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Musicas.Update(musica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MusicaExists(musica.MusicaId))
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
            return View(musica);
        }

        // GET: Musicas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musica = await _context.Musicas
                .Select(s => new DetailsViewModel
                {
                    AlbumNome = s.Album.AlbumNome,
                    MusicaNome = s.MusicaNome,
                    MusicaId = s.MusicaId
                })
                .FirstOrDefaultAsync(m => m.MusicaId == id);
            if (musica == null)
            {
                return NotFound();
            }

            return View(musica);
        }

        // POST: Musicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var musica = await _context.Musicas.FindAsync(id);
            _context.Musicas.Remove(musica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MusicaExists(Guid id)
        {
            return _context.Musicas.Any(e => e.MusicaId == id);
        }
    }
}
