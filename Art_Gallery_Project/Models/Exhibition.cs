using Microsoft.AspNetCore.Identity;

namespace Art_Gallery_Project.Models;

public class Exhibition
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string? Description { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public List<Floor> Floors { get; set; } = new();
    public IdentityUser? User { get; set; }
}

public class Floor
{
    public int Id { get; set; }
    public int FloorNumber { get; set; }

    public List<int> ArtWorks { get; set; } = new();

}