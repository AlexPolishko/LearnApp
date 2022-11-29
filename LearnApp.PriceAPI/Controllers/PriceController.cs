using Microsoft.AspNetCore.Mvc;

namespace LearnApp.PriceAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PriceController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<PriceController> _logger;

    public PriceController(ILogger<PriceController> logger)
    {
        _logger = logger;
    }

    [HttpGet()]
    public Price Get()
    {
        return new Price
        {
            Date = DateTime.Now,
            Amount = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        };
    }
}
