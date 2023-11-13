namespace Art_Gallery_Project.Models;

public class Exhibition
{
    public int Id { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public string Location { get; set; }

    public List<ExhibitionArtWorks> ExhibitionArtWorksList { get; } = new();
}