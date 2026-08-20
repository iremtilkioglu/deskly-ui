using deskly_ui.Models;

namespace deskly_ui.Models;

public class CartItem
{
    public int ProductId { get; set; }

    public Product Product { get; set; } = null!;

    public int Quantity { get; set; } = 1;

    public string? SelectedColor { get; set; }

    public decimal UnitPrice => Product.Price;

    public decimal TotalPrice => Product.Price * Quantity;
}