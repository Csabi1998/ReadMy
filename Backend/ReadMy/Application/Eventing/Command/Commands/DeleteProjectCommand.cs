using Application.Eventing.Command.Dtos;
using Application.Eventing.Command.Response;
using MediatR;

namespace Application.Eventing.Command.Commands
{
    public class DeleteProjectCommand : IRequest<DeleteEntityResponse>
    {
        public DeleteProjectCommand(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
