using System.Text.Json;
using deskly_ui.Models;
using deskly_ui.Models.Session;
using Microsoft.AspNetCore.Http;

namespace deskly_ui.Services;

public class WishlistService
{
    private const string SessionKey = "Deskly.Wishlist";

    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ProductService _productService;

    public WishlistService(
        IHttpContextAccessor httpContextAccessor,
        ProductService productService)
    {
        _httpContextAccessor = httpContextAccessor;
        _productService = productService;
    }

    private ISession Session =>
        _httpContextAccessor.HttpContext?.Session
        ?? throw new InvalidOperationException(
            "WishlistService requires an active HTTP session.");

    private List<WishlistSessionItem> LoadItems()
    {
        var json = Session.GetString(SessionKey);

        if (string.IsNullOrEmpty(json))
        {
            return new List<WishlistSessionItem>();
        }

        var items = JsonSerializer.Deserialize<List<WishlistSessionItem>>(json)
            ?? new List<WishlistSessionItem>();

        var products = _productService.GetAllProducts();

        return items.Where(item =>
        {
            var product = products.FirstOrDefault(
                product => product.Id == item.ProductId);

            if (product == null)
            {
                return false;
            }

            if (product.Variants.Count == 0)
            {
                return string.IsNullOrWhiteSpace(item.SelectedColor);
            }

            return string.IsNullOrWhiteSpace(item.SelectedColor)
                || product.Variants.Any(variant =>
                    string.Equals(
                        variant.ColorName,
                        item.SelectedColor,
                        StringComparison.OrdinalIgnoreCase));
        }).ToList();
    }

    private void SaveItems(List<WishlistSessionItem> items)
    {
        Session.SetString(
            SessionKey,
            JsonSerializer.Serialize(items)
        );
    }

    private static string? NormalizeColor(
        Product product,
        string? selectedColor)
    {
        if (product.Variants.Count == 0)
        {
            if (!string.IsNullOrWhiteSpace(selectedColor))
            {
                throw new ArgumentException(
                    "This product has no color variants.",
                    nameof(selectedColor));
            }

            return null;
        }

        if (string.IsNullOrWhiteSpace(selectedColor))
        {
            return product.Variants[0].ColorName;
        }

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

        return variant.ColorName;
    }

    public IReadOnlyList<WishlistItem> GetItems()
    {
        var products = _productService.GetAllProducts();

        return LoadItems()
            .Select(item => new
            {
                Item = item,
                Product = products.FirstOrDefault(
                    product => product.Id == item.ProductId)
            })
            .Where(result => result.Product != null)
            .Select(result => new WishlistItem
            {
                ProductId = result.Item.ProductId,
                Product = result.Product!,
                SelectedColor = NormalizeColor(
                    result.Product!,
                    result.Item.SelectedColor),
                AddedAt = result.Item.AddedAt
            })
            .ToList();
    }

    public void Add(Product product, string? selectedColor = null)
    {
        selectedColor = NormalizeColor(product, selectedColor);

        var items = LoadItems();

        if (items.Any(item =>
            item.ProductId == product.Id &&
            NormalizeColor(product, item.SelectedColor) == selectedColor))
        {
            return;
        }

        items.Add(new WishlistSessionItem
        {
            ProductId = product.Id,
            SelectedColor = selectedColor,
            AddedAt = DateTime.UtcNow
        });

        SaveItems(items);
    }

    public void Remove(int productId, string? selectedColor = null)
    {
        var product = _productService.GetAllProducts()
            .FirstOrDefault(item => item.Id == productId);

        if (product == null)
        {
            return;
        }

        selectedColor = NormalizeColor(product, selectedColor);

        var items = LoadItems();

        items.RemoveAll(item =>
            item.ProductId == productId &&
            NormalizeColor(product, item.SelectedColor) == selectedColor);

        SaveItems(items);
    }

    public bool Exists(int productId, string? selectedColor = null)
    {
        var product = _productService.GetAllProducts()
            .FirstOrDefault(item => item.Id == productId);

        if (product == null)
        {
            return false;
        }

        selectedColor = NormalizeColor(product, selectedColor);

        return LoadItems().Any(item =>
            item.ProductId == productId &&
            NormalizeColor(product, item.SelectedColor) == selectedColor);
    }

    public int GetCount()
    {
        return GetItems().Count;
    }

    public void Clear()
    {
        Session.Remove(SessionKey);
    }
}
