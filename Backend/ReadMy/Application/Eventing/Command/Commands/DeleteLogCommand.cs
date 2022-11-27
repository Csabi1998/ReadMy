using Application.Eventing.Command.Response;
using MediatR;

namespace Application.Eventing.Command.Commands
{
    public class DeleteLogCommand : IRequest<DeleteEntityResponse>
    {
        public DeleteLogCommand(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
