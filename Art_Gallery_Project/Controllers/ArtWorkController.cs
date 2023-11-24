using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Art_Gallery_Project.Data;
using Art_Gallery_Project.Models;
using Microsoft.AspNetCore.Authorization;

namespace Art_Gallery_Project.Controllers
{
    public class ArtWorkController : Controller
    {
        private readonly Art_Gallery_ProjectContext _context;

        public ArtWorkController(Art_Gallery_ProjectContext context)
        {
            _context = context;
        }

        // GET: ArtWork
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.ArtWork.ToListAsync());
        }

        // GET: ArtWork/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id, string? user)
        {
            if (id == null || _context.ArtWork == null)
            {
                return NotFound();
            }

            var artWork = await _context.ArtWork
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artWork == null)
            {
                return NotFound();
            }

            return View(artWork);
        }

        // GET: ArtWork/Create
        [Authorize(Roles = "Admin,Artist", Policy = "ArtistOnly")]
        public IActionResult Create(string? user)
        {
            return View();
        }

        // POST: ArtWork/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin,Artist", Policy = "ArtistOnly")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string? user,
            [Bind("Id,Title,Medium,Size,Price,PieceDescription,CompletionDate,ImageUrl")]
            ArtWork artWork)
        {
            if (ModelState.IsValid)
            {
                Artist artist = await _context.Artist.FirstOrDefaultAsync(m => m.User.Id == user);
                if (artist == null)
                {
                    return NotFound();
                }

                artist.ArtWorks.Add(artWork);

                _context.Update(artist);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(artWork);
        }

        // GET: ArtWork/Edit/5
        [Authorize(Roles = "Admin,Artist", Policy = "ArtistOnly")]
        public async Task<IActionResult> Edit(int? id, string? user)
        {
            if (id == null || _context.ArtWork == null)
            {
                return NotFound();
            }

            if (!IsArtistOfWork(user, id))
            {
                return RedirectToPage("/Error", new { message = "Unauthorized" });
            }

            var artWork = await _context.ArtWork.FindAsync(id);
            if (artWork == null)
            {
                return NotFound();
            }

            return View(artWork);
        }

        // POST: ArtWork/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Artist", Policy = "ArtistOnly")]
        public async Task<IActionResult> Edit(int id, string? user,
            [Bind("Id,Title,Medium,Size,Price,PieceDescription,CompletionDate,ImageUrl")]
            ArtWork artWork)
        {
            if (id != artWork.Id)
            {
                return NotFound();
            }

            if (!IsArtistOfWork(user, id))
            {
                return RedirectToPage("/Error", new { message = "Unauthorized" });
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artWork);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtWorkExists(artWork.Id))
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

            return View(artWork);
        }

        // GET: ArtWork/Delete/5
        [Authorize(Roles = "Admin,Artist", Policy = "ArtistOnly")]
        public async Task<IActionResult> Delete(int? id, string? user)
        {
            if (id == null || _context.ArtWork == null)
            {
                return NotFound();
            }

            if (!IsArtistOfWork(user, id))
            {
                return RedirectToPage("/Error", new { message = "Unauthorized" });
            }

            var artWork = await _context.ArtWork
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artWork == null)
            {
                return NotFound();
            }

            return View(artWork);
        }

        // POST: ArtWork/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Artist", Policy = "ArtistOnly")]
        public async Task<IActionResult> DeleteConfirmed(int id, string? user)
        {
            if (_context.ArtWork == null)
            {
                return Problem("Entity set 'Art_Gallery_ProjectContext.ArtWork'  is null.");
            }

            if (!IsArtistOfWork(user, id))
            {
                return RedirectToPage("/Error", new { message = "Unauthorized" });
            }

            var artWork = await _context.ArtWork.FindAsync(id);
            if (artWork != null)
            {
                _context.ArtWork.Remove(artWork);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin,Artist", Policy = "ArtistOnly")]
        public async Task<IActionResult> AllForArtist(string? user)
        {
            if (user == null)
            {
                return NotFound();
            }

            var artist = await _context.Artist.AsNoTracking()
                .Include(a => a.ArtWorks) // Ensure ArtWorks are loaded
                .FirstOrDefaultAsync(a => a.User.Id == user);

            if (artist == null)
            {
                return NotFound();
            }


            return View(artist.ArtWorks);
        }

        private bool IsArtistOfWork(string? user, int? id)
        {
            if (user == null || id == null)
            {
                return false;
            }

            var artist = _context.Artist.AsNoTracking()
                .Include(a => a.ArtWorks)
                .FirstOrDefault(a => a.User.Id == user);

            if (artist == null)
            {
                return false;
            }

            var existingArtWork = _context.ArtWork.Local.FirstOrDefault(e => e.Id == id);
            if (existingArtWork != null)
            {
                _context.Entry(existingArtWork).State = EntityState.Detached;
            }

            return artist.ArtWorks.FirstOrDefault(work => work.Id == id) != null;
        }

        private bool ArtWorkExists(int id)
        {
            return (_context.ArtWork?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}