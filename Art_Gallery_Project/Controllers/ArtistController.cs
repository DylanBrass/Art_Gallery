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

        [Authorize(Roles = "Admin,Artist", Policy = "ArtistOnly")]
        public async Task<IActionResult> Details(string? user)
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


        private bool ArtistExists(int id)
        {
            return (_context.Artist?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}