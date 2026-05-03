using CoreFitness.Infrastructure.Identity;
using CoreFitness.Infrastructure.Persistence;
using CoreFitness.Presentation.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreFitness.Presentation.Controllers;

public class AboutMeController : Controller
{
    private readonly UserManager<AppUserIdentity> _userManager;
    private readonly ApplicationDbContext _dbContext;

    public AboutMeController(UserManager<AppUserIdentity> userManager, ApplicationDbContext dbContext)
    {
        _userManager = userManager;
        _dbContext = dbContext;
    }

    [HttpPost]
    public async Task<IActionResult> UpdateUserPersonalInfo(AboutMeViewModel model)
    {
        if (!ModelState.IsValid)
            return RedirectToAction("Index", "MyAccount", new { tab = "about" });

        var identityUser = await _userManager.GetUserAsync(User);
        if (identityUser == null)
            return Challenge();

        var appUser = await _dbContext.AppUsers
            .FirstOrDefaultAsync(x => x.IdentityUserId == identityUser.Id);

        if (appUser == null)
            return NotFound();

        appUser.UpdateUserPersonalInfo(model.FirstName, model.LastName, model.PhoneNumber);
        await _dbContext.SaveChangesAsync();

        return RedirectToAction("Index", "MyAccount", new { tab = "about" });
    }
}