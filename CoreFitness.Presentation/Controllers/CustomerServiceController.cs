using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CoreFitness.Presentation.Controllers;

public class CustomerServiceController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}