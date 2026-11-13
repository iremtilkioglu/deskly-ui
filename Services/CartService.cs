using System.Text.Json;
using deskly_ui.Models;
using deskly_ui.Models.Session;
using Microsoft.AspNetCore.Http;

namespace deskly_ui.Services;

public class CartService
{
    private const string SessionKey = "Deskly.Cart";
    private const int MaxQuantityPerItem = 99;

    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ProductService _productService;

    public CartService(
        IHttpContextAccessor httpContextAccessor,
        ProductService productService)
    {
        _httpContextAccessor = httpContextAccessor;
        _productService = productService;
    }

    private ISession Session =>
        _httpContextAccessor.HttpContext?.Session
        ?? throw new InvalidOperationException(
            "CartService requires an active HTTP session.");

    private List<CartSessionItem> LoadItems()
    {
        var json = Session.GetString(SessionKey);

        if (string.IsNullOrEmpty(json))
        {
            return new List<CartSessionItem>();
        }

        return JsonSerializer.Deserialize<List<CartSessionItem>>(json)
            ?? new List<CartSessionItem>();
    }

    private void SaveItems(List<CartSessionItem> items)
    {
        Session.SetString(
            SessionKey,
            JsonSerializer.Serialize(items)
        );
    }

    public IReadOnlyList<CartItem> GetItems()
    {
        var products = _productService.GetAllProducts();

        return LoadItems()
            .Where(item => item.Quantity > 0)
            .Select(item => new
            {
                Item = item,
                Product = products.FirstOrDefault(
                    product => product.Id == item.ProductId)
            })
            .Where(result => result.Product != null)
            .Select(result => new CartItem
            {
                ProductId = result.Item.ProductId,
                Product = result.Product!,
                Quantity = result.Item.Quantity,
                SelectedColor = result.Item.SelectedColor
            })
            .ToList();
    }

    public void AddProduct(
        Product product,
        int quantity = 1,
        string? selectedColor = null)
    {
        if (quantity < 1 || quantity > MaxQuantityPerItem)
        {
            throw new ArgumentOutOfRangeException(nameof(quantity));
        }

        if (product.Variants.Count > 0)
        {
            var variant = product.Variants.FirstOrDefault(item =>
                string.Equals(
                    item.ColorName,
                    selectedColor,
                    StringComparison.OrdinalIgnoreCase));

            if (variant == null)
            {
                throw new ArgumentException(
                    "Invalid product color.",
                    nameof(selectedColor));
            }

            selectedColor = variant.ColorName;
        }
        else
        {
            if (!string.IsNullOrWhiteSpace(selectedColor))
            {
                throw new ArgumentException(
                    "This product has no color variants.",
                    nameof(selectedColor));
            }

            selectedColor = null;
        }

        var items = LoadItems();

        var existingItem = items.FirstOrDefault(item =>
            item.ProductId == product.Id &&
            item.SelectedColor == selectedColor);

        if (existingItem != null)
        {
            existingItem.Quantity = (int)Math.Min(
                MaxQuantityPerItem,
                (long)existingItem.Quantity + quantity);
        }
        else
        {
            items.Add(new CartSessionItem
            {
                ProductId = product.Id,
                Quantity = quantity,
                SelectedColor = selectedColor
            });
        }

        SaveItems(items);
    }

    public void IncreaseQuantity(
        int productId,
        string? selectedColor = null)
    {
        var items = LoadItems();

        var item = items.FirstOrDefault(item =>
            item.ProductId == productId &&
            item.SelectedColor == selectedColor);

        if (item == null || item.Quantity >= MaxQuantityPerItem)
        {
            return;
        }

        item.Quantity++;

        SaveItems(items);
    }

    public void DecreaseQuantity(
        int productId,
        string? selectedColor = null)
    {
        var items = LoadItems();

        var item = items.FirstOrDefault(item =>
            item.ProductId == productId &&
            item.SelectedColor == selectedColor);

        if (item == null)
        {
            return;
        }

        if (item.Quantity > 1)
        {
            item.Quantity--;
        }
        else
        {
            items.Remove(item);
        }

        SaveItems(items);
    }

    public void RemoveProduct(
        int productId,
        string? selectedColor = null)
    {
        var items = LoadItems();

        items.RemoveAll(item =>
            item.ProductId == productId &&
            item.SelectedColor == selectedColor);

        SaveItems(items);
    }

    public void Clear()
    {
        Session.Remove(SessionKey);
    }

    public int GetTotalQuantity()
    {
        return GetItems().Sum(item => item.Quantity);
    }

    public decimal GetSubtotal()
    {
        return GetItems().Sum(item => item.TotalPrice);
    }
}
