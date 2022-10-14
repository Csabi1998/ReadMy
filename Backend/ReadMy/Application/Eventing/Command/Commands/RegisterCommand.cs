using Application.Eventing.Command.Dtos;
using Application.Eventing.Command.Response;

using MediatR;

namespace Application.Eventing.Command.Commands
{
    public class RegisterCommand : IRequest<RegisterResponse>
    {
        public RegisterCommand(RegisterDto register)
        {
            Register = register;
        }

        public RegisterDto Register { get; }
    }
}
