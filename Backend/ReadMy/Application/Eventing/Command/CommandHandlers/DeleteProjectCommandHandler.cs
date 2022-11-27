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
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, DeleteEntityResponse>
    {
        private readonly ReadMyDbContext context;
        private readonly ICurrentUserService userService;

        public DeleteProjectCommandHandler(ReadMyDbContext context, ICurrentUserService userService)
        {
            this.context = context;
            this.userService = userService;
        }
        public async Task<DeleteEntityResponse> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var projekt = await context.Projects
                .Include(x => x.Tasks)
                .ThenInclude(x => x.Logs)
                .SingleOrDefaultAsync(x => x.Id == request.Id && (x.Participants.Any(p => p.Id == userService.User.UserId) || x.CreatorId == userService.User.UserId || userService.User.Role == ReadMyRoles.Admin), cancellationToken);

            if (projekt is null)
            {
                throw new BusinessException(ProjektMessages.ProjektNotFound);
            }

            foreach (var task in projekt.Tasks)
            {
                context.Remove(task);

                foreach (var log in task.Logs)
                {
                    context.Remove(log);
                }
            }

            context.Remove(projekt);

            await context.SaveChangesAsync(cancellationToken);

            return new DeleteEntityResponse(projekt.Id);
        }
    }
}
