using deskly_ui.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace deskly_ui.Controllers;

public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Login(string? returnUrl = null)
    {
        var model = new LoginViewModel
        {
            ReturnUrl = returnUrl
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        // Demo giriş bilgileri
        HttpContext.Session.SetString("IsLoggedIn", "true");
        HttpContext.Session.SetString("UserName", "İrem");
        HttpContext.Session.SetString("UserFullName", "İrem Tilkioğlu");
        HttpContext.Session.SetString("UserEmail", model.Email);

        if (!string.IsNullOrWhiteSpace(model.ReturnUrl)
            && Url.IsLocalUrl(model.ReturnUrl))
        {
            return LocalRedirect(model.ReturnUrl);
        }

        return RedirectToAction(nameof(Profile));
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        TempData["Success"] =
            "Hesabınız oluşturuldu. Şimdi giriş yapabilirsiniz.";

        return RedirectToAction(nameof(Login));
    }

    [HttpGet]
    public IActionResult ForgotPassword()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ForgotPassword(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            ModelState.AddModelError(
                string.Empty,
                "E-posta adresi zorunludur."
            );

            return View();
        }

        TempData["Success"] =
            "Şifre yenileme bağlantısı e-posta adresinize gönderildi.";

        return RedirectToAction(nameof(Login));
    }

    [HttpGet]
    public IActionResult Profile()
    {
        if (!IsLoggedIn())
        {
            return RedirectToAction(
                nameof(Login),
                new { returnUrl = Url.Action(nameof(Profile)) }
            );
        }

        return View();
    }

    [HttpGet]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();

        return RedirectToAction("Index", "Home");
    }

    private bool IsLoggedIn()
    {
        return HttpContext.Session.GetString("IsLoggedIn") == "true";
    }
}