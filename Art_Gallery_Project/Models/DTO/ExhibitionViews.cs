namespace Art_Gallery_Project.Models.DTO;

public class ExhibitionViews
{
    public Exhibition exhibition { get; set; } = new();
    public List<FloorViews> Floors { get; set; } = new();
}