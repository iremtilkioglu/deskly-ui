using deskly_ui.Models;

namespace deskly_ui.ViewModels;

public class CartViewModel
{
    public IReadOnlyList<CartItem> Items { get; set; } = new List<CartItem>();

    public decimal Subtotal { get; set; }

    public decimal Shipping { get; set; }

    public decimal Discount { get; set; }

    public decimal Total => Subtotal + Shipping - Discount;

    public int TotalQuantity => Items.Sum(item => item.Quantity);
}