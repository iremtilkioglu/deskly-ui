using deskly_ui.Services;
using Microsoft.AspNetCore.Mvc;

namespace deskly_ui.Controllers;

public class WishlistController : Controller
{
    private readonly WishlistService _wishlistService;
    private readonly ProductService _productService;

    public WishlistController(
        WishlistService wishlistService,
        ProductService productService)
    {
        _wishlistService = wishlistService;
        _productService = productService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var items = _wishlistService.GetItems();

        return View(items);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Add(int productId)
    {
        var product = _productService
            .GetAllProducts()
            .FirstOrDefault(item => item.Id == productId);

        if (product == null)
        {
            return NotFound();
        }

        _wishlistService.Add(product);

        if (IsAjaxRequest())
        {
            return Json(new
            {
                success = true,
                isFavorite = true,
                count = _wishlistService.GetCount()
            });
        }

        return RedirectToPreviousPage();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Remove(int productId)
    {
        _wishlistService.Remove(productId);

        if (IsAjaxRequest())
        {
            return Json(new
            {
                success = true,
                isFavorite = false,
                count = _wishlistService.GetCount()
            });
        }

        return RedirectToPreviousPage();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Clear()
    {
        _wishlistService.Clear();

        return RedirectToAction(nameof(Index));
    }

    private bool IsAjaxRequest()
    {
        return Request.Headers["X-Requested-With"].ToString()
            == "XMLHttpRequest";
    }

    private IActionResult RedirectToPreviousPage()
    {
        var referer = Request.Headers.Referer.ToString();

        if (!string.IsNullOrWhiteSpace(referer))
        {
            return Redirect(referer);
        }

        return RedirectToAction(nameof(Index));
    }
}