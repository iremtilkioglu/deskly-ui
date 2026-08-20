using deskly_ui.Models;

namespace deskly_ui.Services;

public class CartService
{
    private readonly List<CartItem> _items = new();

    public IReadOnlyList<CartItem> GetItems()
    {
        return _items;
    }

    public void AddProduct(Product product, int quantity = 1, string? selectedColor = null)
    {
        if (quantity < 1)
        {
            quantity = 1;
        }

        var existingItem = _items.FirstOrDefault(item =>
            item.ProductId == product.Id &&
            item.SelectedColor == selectedColor);

        if (existingItem != null)
        {
            existingItem.Quantity += quantity;
            return;
        }

        _items.Add(new CartItem
        {
            ProductId = product.Id,
            Product = product,
            Quantity = quantity,
            SelectedColor = selectedColor
        });
    }

    public void IncreaseQuantity(int productId, string? selectedColor = null)
    {
        var item = FindItem(productId, selectedColor);

        if (item != null)
        {
            item.Quantity++;
        }
    }

    public void DecreaseQuantity(int productId, string? selectedColor = null)
    {
        var item = FindItem(productId, selectedColor);

        if (item == null)
        {
            return;
        }

        if (item.Quantity > 1)
        {
            item.Quantity--;
            return;
        }

        _items.Remove(item);
    }

    public void RemoveProduct(int productId, string? selectedColor = null)
    {
        var item = FindItem(productId, selectedColor);

        if (item != null)
        {
            _items.Remove(item);
        }
    }

    public void Clear()
    {
        _items.Clear();
    }

    public int GetTotalQuantity()
    {
        return _items.Sum(item => item.Quantity);
    }

    public decimal GetSubtotal()
    {
        return _items.Sum(item => item.TotalPrice);
    }

    private CartItem? FindItem(int productId, string? selectedColor)
    {
        return _items.FirstOrDefault(item =>
            item.ProductId == productId &&
            item.SelectedColor == selectedColor);
    }
}