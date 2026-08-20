using deskly_ui.Models;

namespace deskly_ui.Services;

public class WishlistService
{
    private readonly List<WishlistItem> _items = new();

    public IReadOnlyList<WishlistItem> GetItems()
    {
        return _items;
    }

    public void Add(Product product)
    {
        var alreadyExists = _items.Any(item =>
            item.ProductId == product.Id
        );

        if (alreadyExists)
        {
            return;
        }

        _items.Add(new WishlistItem
        {
            ProductId = product.Id,
            Product = product,
            AddedAt = DateTime.Now
        });
    }

    public void Remove(int productId)
    {
        var item = _items.FirstOrDefault(item =>
            item.ProductId == productId
        );

        if (item != null)
        {
            _items.Remove(item);
        }
    }

    public bool Exists(int productId)
    {
        return _items.Any(item =>
            item.ProductId == productId
        );
    }

    public int GetCount()
    {
        return _items.Count;
    }

    public void Clear()
    {
        _items.Clear();
    }
}