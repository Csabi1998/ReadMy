using Application.Constants;
using Application.Eventing.Command.Commands;
using Application.Eventing.Command.Dtos;
using Application.Eventing.Command.Response;
using Application.Eventing.Query.Querys;
using Application.Eventing.Query.ViewModels;
using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ReadMy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LogsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{taskId}")]
        public async Task<ActionResult<LogsListViewModel>> GetLogsAsync([FromRoute] string taskId, CancellationToken cancellationToken) 
        {
            return await _mediator.Send(new GetLogsQuery(taskId), cancellationToken);
        }
        
        [HttpGet("export")]
        public async Task<ActionResult> LogsExcelExportAsync(CancellationToken cancellationToken) 
        {
            var excelResult = await _mediator.Send(new LogsExcelExportQuery(), cancellationToken);

            return File(excelResult.Bytes, ContentTypes.XLSX, excelResult.Name);
        }

        [HttpPost]
        public async Task<ActionResult<CreateLogResponse>> CreateTaskunitAsync([FromBody] CreateLogDto dto, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new CreateLogCommand(dto), cancellationToken);
        }

        [HttpPut]
        public async Task<ActionResult<UpdateLogResponse>> UpdataTaskunitAsync([FromBody] UpdateLogDto dto, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new UpdateLogCommand(dto), cancellationToken);
        }

    }
}
