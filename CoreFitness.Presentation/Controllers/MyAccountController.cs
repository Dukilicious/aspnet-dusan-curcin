using CoreFitness.Infrastructure.Identity;
using CoreFitness.Presentation.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreFitness.Presentation.Controllers;

public class MyAccountController : Controller
{
    private readonly SignInManager<AppUserIdentity> _signInManager;

    public MyAccountController(SignInManager<AppUserIdentity> signInManager)
    {
        _signInManager = signInManager;
    }

    public IActionResult Index(string tab = "about")
    {
        var vm = new MyAccountViewModel
        {
            ActiveTab = tab
        };

        return View(vm);
    }

    public async Task<IActionResult> UpdateUserInfo(string? firstname, string? lastname, string? phonenumber)
    {
        
    }

    // Logout Method is AI generated
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
    }
}