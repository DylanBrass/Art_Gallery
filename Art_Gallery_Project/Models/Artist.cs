using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Identity;

namespace Art_Gallery_Project.Models;

public class Artist
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Bio { get; set; }

    public List<ArtWork> ArtWorks { get; } = new();

    public IdentityUser? User { get; set; }
}