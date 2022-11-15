using Application.Eventing.Command.Dtos;
using Application.Eventing.Command.Response;
using MediatR;

namespace Application.Eventing.Command.Commands
{
    public class CreateProjektCommand : IRequest<CreateProjektResponse>
    {
        public CreateProjektCommand(CreateProjektDto dto)
        {
            Dto = dto;
        }

        public CreateProjektDto Dto { get; }
    }
}
