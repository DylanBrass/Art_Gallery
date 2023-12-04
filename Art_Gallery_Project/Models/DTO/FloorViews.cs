namespace Art_Gallery_Project.Models.DTO;

public class FloorViews
{
    public List<ArtWork> ArtWorks { get; set; } = new();
    public int FloorNumber { get; set; }
}