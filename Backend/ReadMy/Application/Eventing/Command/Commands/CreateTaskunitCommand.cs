using Application.Eventing.Command.Dtos;
using Application.Eventing.Command.Response;

using MediatR;

namespace Application.Eventing.Command.Commands
{
    public class CreateTaskunitCommand : IRequest<CreateTaskunitResponse>
    {
        public CreateTaskunitCommand(CreateTaskunitDto dto)
        {
            Dto = dto;
        }

        public CreateTaskunitDto Dto { get; }
    }
}
