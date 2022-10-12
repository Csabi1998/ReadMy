using Application.Eventing.Command.Response;
using MediatR;

namespace Application.Eventing.Command.Commands
{
    public class FirstCommand : IRequest<FirstResponse>
    {
    }
}
