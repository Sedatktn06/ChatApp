using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Selam");
    }
}
