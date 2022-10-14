using Application.Eventing.Command.Commands;
using Application.Eventing.Command.Response;

using Common.Services;

using MediatR;

namespace Application.Eventing.Command.CommandHandlers
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IJwtTokenService tokenService;

        public LoginCommandHandler(IJwtTokenService tokenService)
        {
            this.tokenService = tokenService;
        }
        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return new LoginResponse("");
        }
    }
}
