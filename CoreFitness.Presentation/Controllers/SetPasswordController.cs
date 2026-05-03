using CoreFitness.Infrastructure.Identity;
using CoreFitness.Presentation.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreFitness.Presentation.Controllers;

public class SetPasswordController : Controller
{
    private readonly UserManager<AppUserIdentity> _userManager;
    private readonly SignInManager<AppUserIdentity> _signInManager;

    public SetPasswordController(UserManager<AppUserIdentity> userManager, SignInManager<AppUserIdentity> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public IActionResult Index(string email)
    {
        var vm = new SetPasswordViewModel
        {
            Email = email
        };

        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Index(SetPasswordViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var user = new AppUserIdentity
        {
            UserName = model.Email,
            Email = model.Email,
        };

        var result = await _userManager.CreateAsync(user, model.Password);

        // if statement below is AI generated
        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "MyAccount");
        }
        else
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }
    }
}