using Application.Eventing.Command.Commands;
using Application.Eventing.Command.Dtos;
using Application.Eventing.Command.Response;
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

        [HttpPost("register")]
        [Authorize(ReadMyRoles.Admin)]
        public async Task<ActionResult<RegisterResponse>> Regiszter([FromBody] RegisterDto request)
        {
            return await mediator.Send(new RegisterCommand(request), HttpContext.RequestAborted);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginDto request)
        {
            return await mediator.Send(new LoginCommand(request), HttpContext.RequestAborted);
        }
    }
}
