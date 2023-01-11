using Microsoft.AspNetCore.Mvc;

namespace ShortenUrl.Controllers;

[Route("error")]
public class ErrorController : Controller
{
    private readonly ILogger<ErrorController> _logger;

    public ErrorController(ILogger<ErrorController> logger)
    {
        _logger = logger;
    }
    
    
    [Route("404")]
    public IActionResult NotFound()
    {
        return View();
    }
    [Route("500")]
    public IActionResult UnhandledException()
    {
        return View();
    }
    
}