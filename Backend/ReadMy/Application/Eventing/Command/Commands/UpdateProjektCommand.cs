using Application.Eventing.Command.Dtos;
using Application.Eventing.Command.Response;
using MediatR;

namespace Application.Eventing.Command.Commands
{
    public class UpdateProjektCommand : IRequest<UpdateProjektResponse>
    {
        public UpdateProjektCommand(UpdateProjektDto dto)
        {
            Dto = dto;
        }

        public UpdateProjektDto Dto { get; }
    }
}
