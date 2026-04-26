using Microsoft.AspNetCore.Mvc;

namespace CoreFitness.Presentation.Controllers;

public class BecomeMemberController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}