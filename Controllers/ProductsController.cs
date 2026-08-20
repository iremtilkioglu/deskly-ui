using Microsoft.AspNetCore.Mvc;
using deskly_ui.Services;

namespace deskly_ui.Controllers;

public class ProductsController : Controller
{
    private readonly ProductService _productService;

    public ProductsController(ProductService productService)
    {
        _productService = productService;
    }

    public IActionResult Index()
    {
        var products = _productService.GetAllProducts();
        return View(products);
    }

    public IActionResult Detail(int id)
    {
        var product = _productService
            .GetAllProducts()
            .FirstOrDefault(x => x.Id == id);

        if (product == null)
            return NotFound();

        return View(product);
    }
}