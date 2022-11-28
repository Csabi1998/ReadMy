using Application.Eventing.Command.Dtos;
using Application.Eventing.Command.Response;
using MediatR;

namespace Application.Eventing.Command.Commands
{
    public class RemoveProjektParticipantCommand : IRequest<UpdateEntityResponse>
    {
        public RemoveProjektParticipantCommand(RemoveProjektParticipantDto dto)
        {
            Dto = dto;
        }

        public RemoveProjektParticipantDto Dto { get; }
    }
}
