using CoreFitness.Presentation.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CoreFitness.Presentation.Controllers;

public class BecomeMemberController : Controller
{
    public IActionResult Index()
    {
        return View(new EnterEmailViewModel());
    }



    [HttpPost]
    public IActionResult EnterEmail(EnterEmailViewModel model)
    {
        if (!ModelState.IsValid)
            return View("Index", model);

        return RedirectToAction("Index", "SetPassword", new { email = model.Email});
    }
}