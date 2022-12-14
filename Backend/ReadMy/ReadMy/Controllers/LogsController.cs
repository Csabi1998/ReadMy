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

        [HttpGet]
        public async Task<ActionResult<LogsListViewModel>> GetLogsAsync(CancellationToken cancellationToken) 
        {
            return await _mediator.Send(new GetLogsQuery(), cancellationToken);
        }
        
        [HttpGet("list/{taskId}")]
        public async Task<ActionResult<LogsListViewModel>> GetLogsByTaskIdAsync([FromRoute] string taskId, CancellationToken cancellationToken) 
        {
            return await _mediator.Send(new GetLogsByTaskIdQuery(taskId), cancellationToken);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<LogViewModel>> GetLogAsync([FromRoute] string id, CancellationToken cancellationToken) 
        {
            return await _mediator.Send(new GetLogQuery(id), cancellationToken);
        }
        
        [HttpGet("export")]
        public async Task<ActionResult> LogsExcelExportAsync(CancellationToken cancellationToken) 
        {
            var excelResult = await _mediator.Send(new LogsExcelExportQuery(), cancellationToken);

            return File(excelResult.Bytes, ContentTypes.XLSX, excelResult.Name);
        }

        [HttpPost]
        public async Task<ActionResult<CreateLogResponse>> CreateLogAsync([FromBody] CreateLogDto dto, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new CreateLogCommand(dto), cancellationToken);
        }

        [HttpPut]
        public async Task<ActionResult<UpdateLogResponse>> UpdataLogAsync([FromBody] UpdateLogDto dto, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new UpdateLogCommand(dto), cancellationToken);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteEntityResponse>> DeleteLogAsync([FromRoute] string id, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new DeleteLogCommand(id), cancellationToken);
        }
    }
}
