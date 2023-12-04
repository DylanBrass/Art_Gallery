using Art_Gallery_Project.Data;
using Art_Gallery_Project.Models;
using Art_Gallery_Project.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Art_Gallery_Project.Controllers;

public class ExhibitionController : Controller
{
    private readonly Art_Gallery_ProjectContext _context;

    public ExhibitionController(Art_Gallery_ProjectContext context)
    {
        _context = context;
    }

    // GET
    [AllowAnonymous]
    public IActionResult Index()
    {
        var exhibitions = _context.Exhibition.Include(exhibition => exhibition.Floors).ToList();
        var exhibitionViews = new List<ExhibitionViews>();
        foreach (var exhibition in exhibitions)
        {
            var exhibitionView = new ExhibitionViews();
            exhibitionView.exhibition = exhibition;
            foreach (var floor in exhibition.Floors)
            {
                var floorView = new FloorViews();
                floorView.FloorNumber = floor.FloorNumber;
                foreach (var art in floor.ArtWorks)
                {
                    var artWork = _context.ArtWork.FirstOrDefault(a => a.Id == art);
                    if (artWork != null)
                    {
                        floorView.ArtWorks.Add(artWork);
                    }
                }

                {
                }

                exhibitionView.Floors.Add(floorView);
            }

            exhibitionViews.Add(exhibitionView);
        }

        return View(exhibitionViews);
    }

    [Authorize(Roles = "Customer")]
    public IActionResult Create()
    {
        return View();
    }

    [Authorize(Roles = "Customer")]
    [HttpPost]
    public IActionResult Create(string name, string description, DateOnly startDate, DateOnly endDate)
    {
        var exhibition = new Exhibition()
        {
            Title = name,
            Description = description,
            StartDate = startDate,
            EndDate = endDate
        };
        exhibition.User = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
        _context.Exhibition.Add(exhibition);
        _context.SaveChanges();
        return RedirectToAction("AddFloor", "Exhibition", new { exhibitionId = exhibition.Id });
    }

    [Authorize(Roles = "Customer")]
    public IActionResult AddFloor(int exhibitionId)
    {
        Exhibition? exhibition = _context.Exhibition.Include(e => e.Floors).FirstOrDefault(e => e.Id == exhibitionId);
        if (exhibition == null)
        {
            return NotFound();
        }

        var artWorks = _context.ArtWork.ToList();
        AddFloorViewModel model = new()
        {
            ExhibitionId = exhibitionId,
            ArtWorks = artWorks
        };
        return View(model);
    }

    [Authorize(Roles = "Customer")]
    [HttpPost]
    public IActionResult AddFloor(int exhibitionId, int floorNumber, List<int> artWorks)
    {
        Exhibition? exhibition = _context.Exhibition.Include(e => e.Floors).FirstOrDefault(e => e.Id == exhibitionId);

        if (exhibition == null)
        {
            return NotFound();
        }

        Floor? fl = exhibition.Floors.FirstOrDefault(f => f.FloorNumber == floorNumber);

        if (fl != null)
        {
            return BadRequest();
        }

        var floor = new Floor()
        {
            FloorNumber = floorNumber
        };

        foreach (var artId in artWorks)
        {
            ArtWork? artWorkFound = _context.ArtWork.AsNoTracking()
                .FirstOrDefault(a => a.Id == artId);
            if (artWorkFound == null)
            {
                return BadRequest();
            }

            floor.ArtWorks.Add(artWorkFound.Id);
        }

        exhibition.Floors.Add(floor);

        _context.SaveChanges();

        return RedirectToAction("AddFloor", "Exhibition", new { exhibitionId = exhibition.Id });
    }
}