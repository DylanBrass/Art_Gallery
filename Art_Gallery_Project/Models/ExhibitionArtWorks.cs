namespace Art_Gallery_Project.Models;

public class ExhibitionArtWorks
{
    public int Id { get; set; }


    public int ExhibitionId { get; set; }
    public int ArtWorkId { get; set; }

    public ArtWork ArtWork { get; set; } = null!;
    public Exhibition Exhibition { get; set; } = null!;
}