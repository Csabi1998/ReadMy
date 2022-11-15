using Application.Eventing.Command.Dtos;
using Application.Eventing.Command.Response;
using MediatR;

namespace Application.Eventing.Command.Commands
{
    public class CreateLogCommand : IRequest<CreateLogResponse>
    {
        public CreateLogCommand(CreateLogDto dto)
        {
            Dto = dto;
        }

        public CreateLogDto Dto { get; }
    }
}
