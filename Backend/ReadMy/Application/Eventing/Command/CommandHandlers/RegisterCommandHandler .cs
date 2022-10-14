using Application.Eventing.Command.Commands;
using Application.Eventing.Command.Response;

using Common.Authorization;
using Common.Services;

using Domain.Entities;

using MediatR;

using Microsoft.AspNetCore.Identity;

namespace Application.Eventing.Command.CommandHandlers
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResponse>
    {
        private readonly UserManager<ReadMyUser> userManager;

        public RegisterCommandHandler(UserManager<ReadMyUser> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = new ReadMyUser { UserName = request.Register.UserName, FullName = request.Register.FullName};
            var response = await userManager.CreateAsync(user, request.Register.Password);
            if (!response.Succeeded) throw new ArgumentException(response.Errors.ToString());
            await userManager.AddToRoleAsync(user, ReadMyRoles.Worker);
            return new RegisterResponse();
        }
    }
}
