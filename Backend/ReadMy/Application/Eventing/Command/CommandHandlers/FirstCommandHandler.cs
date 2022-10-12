using Application.Eventing.Command.Commands;
using Application.Eventing.Command.Response;
using MediatR;

namespace Application.Eventing.Command.CommandHandlers
{
    public class FirstCommandHandler : IRequestHandler<FirstCommand, FirstResponse>
    {
        public Task<FirstResponse> Handle(FirstCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new FirstResponse() { Name = "First try" });
        }
    }
}
