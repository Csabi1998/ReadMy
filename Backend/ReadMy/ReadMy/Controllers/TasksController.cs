using Application.Eventing.Command.Commands;
using Application.Eventing.Command.Dtos;
using Application.Eventing.Command.Response;
using Application.Eventing.Query.Querys;
using Application.Eventing.Query.ViewModels;
using Common.Authorization;
using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ReadMy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TasksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("list/{projectId}")]
        public async Task<ActionResult<TaskunitsListViewModel>> GetTaskunitsAsync([FromRoute] string projectId, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetTaskunitsQuery(projectId), cancellationToken);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskunitViewModel>> GetTaskunitAsync([FromRoute] string id, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetTaskunitQuery(id), cancellationToken);
        }
        
        [HttpPost]
        [Authorize(ReadMyRoles.ProjectManager)]
        public async Task<ActionResult<CreateTaskunitResponse>> CreateTaskunitAsync([FromBody] CreateTaskunitDto dto, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new CreateTaskunitCommand(dto), cancellationToken);
        }

        [HttpPut]
        [Authorize(ReadMyRoles.ProjectManager)]
        public async Task<ActionResult<UpdateTaskunitResponse>> UpdataTaskunitAsync([FromBody] UpdateTaskunitDto dto, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new UpdateTaskunitCommand(dto), cancellationToken);
        }

    }
}
