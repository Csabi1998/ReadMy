using Application.Eventing.Command.Commands;
using Application.Eventing.Command.Dtos;
using Application.Eventing.Command.Response;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ReadMy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<CreateProjektResponse>> CreateProjectAsync([FromBody] CreateProjektDto dto, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new CreateProjektCommand(dto), cancellationToken);
        }

        [HttpPut]
        public async Task<ActionResult<UpdateProjektResponse>> UpdataProjectAsync([FromBody] UpdateProjektDto dto, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new UpdateProjektCommand(dto), cancellationToken);
        }
        
        [HttpPut("participant")]
        public async Task<ActionResult<UpdateEntityResponse>> AddProjectParticipantAsync([FromBody] AddProjektParticipantDto dto, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new AddProjektParticipantCommand(dto), cancellationToken);
        }

    }
}
