using deskly_ui.Services;
using deskly_ui.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace deskly_ui.Controllers;

public class CartController : Controller
{
    private readonly CartService _cartService;
    private readonly ProductService _productService;

    public CartController(
        CartService cartService,
        ProductService productService)
    {
        _cartService = cartService;
        _productService = productService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var items = _cartService.GetItems();

        var viewModel = new CartViewModel
        {
            Items = items,
            Subtotal = _cartService.GetSubtotal(),
            Shipping = items.Any() ? 149m : 0m,
            Discount = 0m
        };

        return View(viewModel);
    }

    [HttpGet]
    public IActionResult Checkout()
    {
        var items = _cartService.GetItems();

        if (!items.Any())
        {
            return RedirectToAction(nameof(Index));
        }

        var cartViewModel = new CartViewModel
        {
            Items = items,
            Subtotal = _cartService.GetSubtotal(),
            Shipping = 149m,
            Discount = 0m
        };

        var checkoutViewModel = new CheckoutViewModel
        {
            Cart = cartViewModel
        };

        return View(checkoutViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Add(
        int productId,
        int quantity = 1,
        string? selectedColor = null)
    {
        var product = _productService
            .GetAllProducts()
            .FirstOrDefault(item => item.Id == productId);

        if (product == null)
        {
            return NotFound();
        }

        _cartService.AddProduct(
            product,
            quantity,
            selectedColor
        );

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Increase(
        int productId,
        string? selectedColor = null)
    {
        _cartService.IncreaseQuantity(
            productId,
            selectedColor
        );

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Decrease(
        int productId,
        string? selectedColor = null)
    {
        _cartService.DecreaseQuantity(
            productId,
            selectedColor
        );

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Remove(
        int productId,
        string? selectedColor = null)
    {
        _cartService.RemoveProduct(
            productId,
            selectedColor
        );

        return RedirectToAction(nameof(Index));
    }
[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult CompleteOrder(CheckoutViewModel model)
{
    var items = _cartService.GetItems();

    if (!items.Any())
    {
        return RedirectToAction(nameof(Index));
    }

    if (!ModelState.IsValid)
    {
        model.Cart = new CartViewModel
        {
            Items = items,
            Subtotal = _cartService.GetSubtotal(),
            Shipping = model.ShippingMethod == "express" ? 249m : 149m,
            Discount = 0m
        };

        return View("Checkout", model);
    }

    var orderNumber = $"DSK-{DateTime.Now:yyyyMMddHHmmss}";

    _cartService.Clear();

    return RedirectToAction(
        nameof(Success),
        new { orderNumber }
    );
}

[HttpGet]
public IActionResult Success(string orderNumber)
{
    if (string.IsNullOrWhiteSpace(orderNumber))
    {
        return RedirectToAction(nameof(Index));
    }

    ViewBag.OrderNumber = orderNumber;

    return View();
}

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Clear()
    {
        _cartService.Clear();

        return RedirectToAction(nameof(Index));
    }
}

