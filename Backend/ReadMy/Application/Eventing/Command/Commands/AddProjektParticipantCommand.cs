using Application.Eventing.Command.Dtos;
using Application.Eventing.Command.Response;
using MediatR;

namespace Application.Eventing.Command.Commands
{
    public class AddProjektParticipantCommand : IRequest<UpdateEntityResponse>
    {
        public AddProjektParticipantCommand(AddProjektParticipantDto dto)
        {
            Dto = dto;
        }

        public AddProjektParticipantDto Dto { get; }
    }
}
