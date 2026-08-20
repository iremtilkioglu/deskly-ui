namespace deskly_ui.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string ShortDescription { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal? OldPrice { get; set; }
    public string Category { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public bool IsFeatured { get; set; }
    public bool IsBestSeller { get; set; }
    public bool IsNew { get; set; }

    public List<ProductVariant> Variants { get; set; } = new();
}
