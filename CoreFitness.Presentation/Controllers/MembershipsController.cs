using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;

namespace CoreFitness.Presentation.Controllers;

public class MembershipsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}