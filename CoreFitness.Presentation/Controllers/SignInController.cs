using CoreFitness.Infrastructure.Identity;
using CoreFitness.Presentation.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreFitness.Presentation.Controllers;

public class SignInController : Controller
{
    private readonly SignInManager<AppUserIdentity> _signInManager;

    public SignInController(SignInManager<AppUserIdentity> signInManager)
    {
        _signInManager = signInManager;
    }

    public IActionResult Index()
    {
        return View(new SignInViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Index(SignInViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, lockoutOnFailure: false);

        if (result.Succeeded)
        {
            return RedirectToAction("Index", "MyAccount");
        }
        else
        {
            ModelState.AddModelError("", "Invalid login attempt.");
            return View(model);
        }
    }
}