using Application.Eventing.Command.Dtos;
using Application.Eventing.Command.Response;

using MediatR;

namespace Application.Eventing.Command.Commands
{
    public class UpdateTaskunitCommand : IRequest<UpdateTaskunitResponse>
    {
        public UpdateTaskunitCommand(UpdateTaskunitDto dto)
        {
            Dto = dto;
        }

        public UpdateTaskunitDto Dto { get; }
    }
}
