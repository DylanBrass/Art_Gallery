using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Art_Gallery_Project.Data;
using Art_Gallery_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Art_Gallery_Project.Controllers
{
    public class ArtistController : Controller
    {
        private readonly Art_Gallery_ProjectContext _context;

        public ArtistController(Art_Gallery_ProjectContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Details(int id)
        {
            var artist = await _context.Artist
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }


        [Authorize(Roles = "Artist", Policy = "ArtistOnly")]
        public async Task<IActionResult> Edit(string? user)
        {
            if (user == null)
            {
                return NotFound();
            }

            var artist = await _context.Artist
                .FirstOrDefaultAsync(m => m.User.Id == user);
            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }

        [Authorize(Roles = "Artist")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string? user,
            [Bind("Id,FirstName, LastName, Bio, User")]
            Artist artist)
        {
            if (id != artist.Id)
            {
                return NotFound();
            }


            artist.User = await _context.Users.FindAsync(user);

            if (artist.User == null)
            {
                return NotFound();
            }


            try
            {
                artist.User = await _context.Users.FindAsync(artist.User.Id);
                _context.Update(artist);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistExists(artist.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction("Details", "Artist", new { user = user });
        }


        private bool ArtistExists(int id)
        {
            return (_context.Artist?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}