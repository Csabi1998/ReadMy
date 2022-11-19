using Application.Eventing.Command.Commands;
using Application.Eventing.Command.Dtos;
using Application.Eventing.Command.Response;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace ReadMy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<CreateProjektResponse> CreateProjectAsync([FromBody] CreateProjektDto dto, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new CreateProjektCommand(dto), cancellationToken);
        }

        [HttpPut]
        public async Task<UpdateProjektResponse> UpdataProjectAsync([FromBody] UpdateProjektDto dto, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new UpdateProjektCommand(dto), cancellationToken);
        }

    }
}
