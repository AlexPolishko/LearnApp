using LearnApp.PriceAPI.Models;
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

    [HttpGet]
    public IActionResult Get(int resultType=0)
    {
        _logger.LogInformation("Price Get Message with result=" + resultType);

        if (resultType == 0)
            return Ok(new Price
            {
                Date = DateTime.Now,
                Amount = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            });

        return StatusCode(500);
    }

    [HttpGet("/api/{priceId}/auto")]
    public IActionResult GetSpecificPrice(int priceId)
    {
        _logger.LogInformation("Price GetSpecificPrice Message with priceId=" + priceId);

        return Ok(new Price
        {
            Date = DateTime.Now,
            Amount = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        });
    }

    [HttpPost]
    public IActionResult SetPrice(PriceUpdateModel updateRequest)
    {
        _logger.LogInformation("Price Set Message with result=");

        return Ok(42);
    }
}
