using Application.Constants;
using Application.Eventing.Command.Commands;
using Application.Eventing.Command.Response;

using Common.Authorization;
using Common.Exceptions;

using Infrastructure;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace Application.Eventing.Command.CommandHandlers
{
    public class UpdateProjektCommandHandler : IRequestHandler<UpdateProjektCommand, UpdateProjektResponse>
    {
        private readonly ReadMyDbContext context;
        private readonly ICurrentUserService userService;

        public UpdateProjektCommandHandler(ReadMyDbContext context, ICurrentUserService userService)
        {
            this.context = context;
            this.userService = userService;
        }
        public async Task<UpdateProjektResponse> Handle(UpdateProjektCommand request, CancellationToken cancellationToken)
        {
            var projekt = await context.Projects.SingleOrDefaultAsync(x => x.Id == request.Dto.Id, cancellationToken);

            if (projekt == null)
            {
                throw new BusinessException(ProjektMessages.ProjektNotFound);
            }

            if (projekt.CreatorId != userService.User.UserId && userService.User.Role != ReadMyRoles.Admin)
            {
                throw new BusinessException(ProjektMessages.ProjektModifyOnlyCreator);
            }

            projekt.Modify(request.Dto.Name, request.Dto.Description);

            await context.SaveChangesAsync(cancellationToken);

            return new UpdateProjektResponse();
        }
    }
}
