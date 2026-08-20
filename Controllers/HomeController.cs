using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using deskly_ui.Models;
using deskly_ui.Services;
using deskly_ui.ViewModels;

namespace deskly_ui.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ProductService _productService;

    public HomeController(
        ILogger<HomeController> logger,
        ProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    public IActionResult Index()
    {
        var products = _productService.GetAllProducts();

        var blogPosts = new List<BlogPost>
        {
            new BlogPost
            {
                Id = 1,
                Title = "Daha Düzenli Bir Masa İçin 5 Öneri",
                Slug = "daha-duzenli-bir-masa-icin-5-oneri",
                Summary = "Çalışma alanınızı sadeleştirmek ve daha verimli hale getirmek için uygulanabilir öneriler.",
                Content = "Blog detay içeriği burada yer alacak.",
                ImageUrl = "/images/blog/blog-1.png",
                PublishDate = new DateTime(2026, 4, 10),
                Category = "Verimlilik"
            },
            new BlogPost
            {
                Id = 2,
                Title = "Minimal Çalışma Alanı Nasıl Kurulur?",
                Slug = "minimal-calisma-alani-nasil-kurulur",
                Summary = "Az ama doğru ürünlerle daha dengeli ve modern bir masa düzeni kurmanın yolları.",
                Content = "Blog detay içeriği burada yer alacak.",
                ImageUrl = "/images/blog/blog-2.png",
                PublishDate = new DateTime(2026, 4, 8),
                Category = "İlham"
            },
            new BlogPost
            {
                Id = 3,
                Title = "Masa Aydınlatmasında Doğru Seçim Rehberi",
                Slug = "masa-aydinlatmasinda-dogru-secim-rehberi",
                Summary = "Işık tonu, konum ve kullanım senaryolarına göre masa lambası seçimi için kısa rehber.",
                Content = "Blog detay içeriği burada yer alacak.",
                ImageUrl = "/images/blog/blog-3.png",
                PublishDate = new DateTime(2026, 4, 5),
                Category = "Aydınlatma"
            }
        };

        var viewModel = new HomeViewModel
        {
            FeaturedProducts = products
                .Where(product => product.IsFeatured)
                .ToList(),

            NewProducts = products
                .Where(product => product.IsNew)
                .ToList(),

            LatestBlogPosts = blogPosts
                .OrderByDescending(post => post.PublishDate)
                .Take(3)
                .ToList()
        };

        return View(viewModel);
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(
        Duration = 0,
        Location = ResponseCacheLocation.None,
        NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel
        {
            RequestId = Activity.Current?.Id
                ?? HttpContext.TraceIdentifier
        });
    }
}