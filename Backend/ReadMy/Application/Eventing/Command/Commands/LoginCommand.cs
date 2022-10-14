using Application.Eventing.Command.Dtos;
using Application.Eventing.Command.Response;

using MediatR;

namespace Application.Eventing.Command.Commands
{
    public class LoginCommand : IRequest<LoginResponse>
    {
        public LoginCommand(LoginDto login)
        {
            Login = login;
        }

        public LoginDto Login { get; }
    }
}
