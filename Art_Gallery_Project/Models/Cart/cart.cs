namespace Art_Gallery_Project.Models.Cart;

public class Cart
{
    public List<CartLine?> Lines { get; set; } = new List<CartLine?>();

    public void AddItem(ArtWork artwork, int quantity)
    {
        CartLine? line = Lines
            .FirstOrDefault(b => b.ArtWork.Id == artwork.Id);
        if (line == null)
        {
            Lines.Add(new CartLine
            {
                ArtWork = artwork,
                Quantity = quantity
            });
        }
        else
        {
            line.Quantity += quantity;
        }
    }

    public void RemoveLine(ArtWork artWork) =>
        Lines.RemoveAll(l => l.ArtWork.Id == artWork.Id);

    public decimal ComputeTotalValue() =>
        Lines.Sum(e => e.ArtWork.Price * e.Quantity);

    public void Clear() => Lines.Clear();
}

public class CartLine
{
    public int CartLineID { get; set; }
    public ArtWork ArtWork { get; set; }
    public int Quantity { get; set; }
}