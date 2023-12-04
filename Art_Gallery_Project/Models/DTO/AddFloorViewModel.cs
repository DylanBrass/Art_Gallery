namespace Art_Gallery_Project.Models.DTO;

public class AddFloorViewModel
{
    public int ExhibitionId { get; set; }
    public List<ArtWork> ArtWorks { get; set; } = new();
}