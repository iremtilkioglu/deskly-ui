using deskly_ui.Models;

namespace deskly_ui.ViewModels;

public class HomeViewModel
{
    public List<Product> FeaturedProducts { get; set; } = new();
    public List<Product> NewProducts { get; set; } = new();
    public List<BlogPost> LatestBlogPosts { get; set; } = new();
}