using Application.Eventing.Command.Dtos;
using Application.Eventing.Command.Response;

using MediatR;

namespace Application.Eventing.Command.Commands
{
    public class UpdateLogCommand : IRequest<UpdateLogResponse>
    {
        public UpdateLogCommand(UpdateLogDto dto)
        {
            Dto = dto;
        }

        public UpdateLogDto Dto { get; }
    }
}
