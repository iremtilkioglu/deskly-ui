namespace deskly_ui.Models.Session;

public sealed class CartSessionItem
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public string? SelectedColor { get; set; }
}
