using Application.Eventing.Command.Commands;
using Application.Eventing.Command.Dtos;
using Application.Eventing.Command.Response;
using Application.Eventing.Query.Querys;
using Application.Eventing.Query.ViewModels;

using Common.Authorization;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReadMy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator mediator;

        public UsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UsersListViewModel>> GetUsersAsync(CancellationToken cancellationToken)
        {
            return await mediator.Send(new GetUsersQuery(), cancellationToken);
        }

        [HttpPost("register")]
        [Authorize(ReadMyRoles.Admin)]
        public async Task<ActionResult<RegisterResponse>> RegiszterAsync([FromBody] RegisterDto request, CancellationToken cancellationToken)
        {
            return await mediator.Send(new RegisterCommand(request), cancellationToken);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> LoginAsync([FromBody] LoginDto request, CancellationToken cancellationToken)
        {
            return await mediator.Send(new LoginCommand(request), cancellationToken);
        }
    }
}
