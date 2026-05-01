using CoreFitness.Presentation.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CoreFitness.Presentation.Controllers;

public class SetPasswordController : Controller
{
    public IActionResult Index(string email)
    {
        var vm = new SetPasswordViewModel
        {
            Email = email
        };

        return View();
    }
}