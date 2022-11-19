﻿using Application.Eventing.Command.Commands;
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
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TasksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<CreateTaskunitResponse>> CreateTaskunitAsync([FromBody] CreateTaskunitDto dto, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new CreateTaskunitCommand(dto), cancellationToken);
        }

        [HttpPut]
        public async Task<ActionResult<UpdateTaskunitResponse>> UpdataTaskunitAsync([FromBody] UpdateTaskunitDto dto, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new UpdateTaskunitCommand(dto), cancellationToken);
        }

    }
}