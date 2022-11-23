using Application.Constants;
using Application.Eventing.Command.Commands;
using Application.Eventing.Command.Response;
using Common.Authorization;
using Common.Exceptions;
using Common.Interfaces;
using Common.Services;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Eventing.Command.CommandHandlers
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IJwtTokenService tokenService;
        private readonly SignInManager<ReadMyUser> signInManager;
        private readonly UserManager<ReadMyUser> userManager;

        public LoginCommandHandler(
            IJwtTokenService tokenService,
            SignInManager<ReadMyUser> signInManager,
            UserManager<ReadMyUser> userManager)
        {
            this.tokenService = tokenService;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var result = await signInManager.PasswordSignInAsync(request.Login.UserName, request.Login.Password, true, false);

            if (!result.Succeeded)
            {
                throw new BusinessException(LoginRegisterMessages.LoginFailed);
            }

            var user = await userManager.FindByNameAsync(request.Login.UserName);
            var role = await userManager.GetRolesAsync(user);

            var token = tokenService.CreateToken(user.Id, user.UserName, user.FullName, role.LastOrDefault() ?? ReadMyRoles.Worker);

            return new LoginResponse(token);
        }
    }
}
