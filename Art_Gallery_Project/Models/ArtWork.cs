namespace Art_Gallery_Project.Models;

public class ArtWork
{
    public int Id { get; set; }

    public string Title { get; set; }

    public Mediums Medium { get; set; }

    public string Size { get; set; }

    public decimal Price { get; set; }

    public string PieceDescription { get; set; }

    public DateOnly CompletionDate { get; set; }

    public string ImageUrl { get; set; }

}