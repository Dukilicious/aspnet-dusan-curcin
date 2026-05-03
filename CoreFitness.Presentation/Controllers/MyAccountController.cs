using CoreFitness.Infrastructure.Identity;
using CoreFitness.Infrastructure.Persistence;
using CoreFitness.Presentation.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreFitness.Presentation.Controllers;

public class MyAccountController : Controller
{
    private readonly SignInManager<AppUserIdentity> _signInManager;
    private readonly UserManager<AppUserIdentity> _userManager;
    private readonly ApplicationDbContext _dbContext;

    public MyAccountController(
        SignInManager<AppUserIdentity> signInManager,
        UserManager<AppUserIdentity> userManager,
        ApplicationDbContext dbContext)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _dbContext = dbContext;
    }

    public async Task<IActionResult> Index(string tab = "about")
    {
        var vm = new MyAccountViewModel
        {
            ActiveTab = tab
        };

        if (User.Identity?.IsAuthenticated == true)
        {
            var identityUser = await _userManager.GetUserAsync(User);
            if (identityUser != null)
            {
                var appUser = await _dbContext.AppUsers
                    .FirstOrDefaultAsync(x => x.IdentityUserId == identityUser.Id);

                if (appUser != null)
                {
                    vm.AboutMe = new AboutMeViewModel
                    {
                        FirstName = appUser.UserPersonalInfo?.FirstName,
                        LastName = appUser.UserPersonalInfo?.LastName,
                        PhoneNumber = appUser.UserPersonalInfo?.PhoneNumber,
                    };
                }
            }
        }

        return View(vm);
    }

    // Logout Method is AI generated
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RemoveAccount()
    {
        if (!User.Identity?.IsAuthenticated ?? true)
            return Challenge();

        var identityUser = await _userManager.GetUserAsync(User);
        if (identityUser == null)
            return Challenge();

        var appUser = await _dbContext.AppUsers
            .FirstOrDefaultAsync(x => x.IdentityUserId == identityUser.Id);

        using var transaction = await _dbContext.Database.BeginTransactionAsync();

        if (appUser != null)
        {
            _dbContext.AppUsers.Remove(appUser);
            await _dbContext.SaveChangesAsync();
        }

        var result = await _userManager.DeleteAsync(identityUser);
        if (!result.Succeeded)
        {
            await transaction.RollbackAsync();

            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return RedirectToAction("Index", new { tab = "about" });
        }

        await transaction.CommitAsync();
        await _signInManager.SignOutAsync();

        return RedirectToAction("Index", "Home");
    }
}