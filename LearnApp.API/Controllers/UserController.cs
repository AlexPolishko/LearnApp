using LearnApp.Domain;
using Microsoft.AspNetCore.Mvc;
using LearnApp.Application.Contracts;
using MediatR;
using LearnApp.Application.Reqeusts;

namespace LearnApp.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly IUserService _userService;

    private readonly ILogger<UserController> _logger;

    private IMediator _mediator;

    public UserController(ILogger<UserController> logger, IUserService userService, IMediator mediator)
    {
        _logger = logger;
        _userService = userService;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IEnumerable<User>> Get(int id, CancellationToken cancellationToken)
    {
        var request = new GetUserRequest() { Id = id};
        var user = await _mediator.Send(request, cancellationToken);

        return user;
    }

    [HttpGet("order")]
    public async Task<IEnumerable<Order>> GetOrders([FromRoute]int userId, CancellationToken cancellationToken)
    {
        var request = new GetOrderRequest() { Id = 1 };
        var order = await _mediator.Send(request, cancellationToken);

        return order;
    }
}
