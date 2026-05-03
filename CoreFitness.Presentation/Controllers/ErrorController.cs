using Microsoft.AspNetCore.Mvc;

namespace CoreFitness.Presentation.Controllers;

public class ErrorController : Controller
{

    // AI generated

    [Route("/Error/{statusCode}")]
    public IActionResult Index(int statusCode)
    {
        ViewData["StatusCode"] = statusCode;
        ViewData["Title"] = statusCode switch
        {
            404 => "Oops! Page Not Found",
            500 => "Internal Server Error",
            _ => "Error"
        };

        ViewData["Message"] = statusCode switch
        {
            404 => "The page you are looking for does not exist.",
            500 => "An unexpected error occurred. Please try again later.",
            _ => "An error occurred."
        };

        return View("Error");
    }
}