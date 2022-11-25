using Application.Eventing.Command.Commands;
using Application.Eventing.Command.Response;

using Common.Authorization;

using Domain.Entities;

using Infrastructure;

using MediatR;

namespace Application.Eventing.Command.CommandHandlers
{
    public class CreateProjektCommandHandler : IRequestHandler<CreateProjektCommand, CreateProjektResponse>
    {
        private readonly ReadMyDbContext context;
        private readonly ICurrentUserService userService;

        public CreateProjektCommandHandler(ReadMyDbContext context, ICurrentUserService userService)
        {
            this.context = context;
            this.userService = userService;
        }
        public async Task<CreateProjektResponse> Handle(CreateProjektCommand request, CancellationToken cancellationToken)
        {
            var projekt = new Project(request.Dto.Name, request.Dto.Description, userService.User.UserId);

            context.Add(projekt);
            await context.SaveChangesAsync(cancellationToken);

            return new CreateProjektResponse(projekt.Id);
        }
    }
}
