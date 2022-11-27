using Application.Eventing.Command.Dtos;
using Application.Eventing.Command.Response;
using MediatR;

namespace Application.Eventing.Command.Commands
{
    public class DeleteTaskunitCommand : IRequest<DeleteEntityResponse>
    {
        public DeleteTaskunitCommand(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
