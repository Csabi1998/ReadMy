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
    public class DeleteTaskunitCommandHandler : IRequestHandler<DeleteTaskunitCommand, DeleteEntityResponse>
    {
        private readonly ReadMyDbContext context;
        private readonly ICurrentUserService userService;

        public DeleteTaskunitCommandHandler(ReadMyDbContext context, ICurrentUserService userService)
        {
            this.context = context;
            this.userService = userService;
        }
        public async Task<DeleteEntityResponse> Handle(DeleteTaskunitCommand request, CancellationToken cancellationToken)
        {
            var taskunit = await context.Taskunits
                .Include(x => x.Logs)
                .SingleOrDefaultAsync(x => x.Id == request.Id && (x.Project.Participants.Any(p => p.Id == userService.User.UserId) || x.Project.CreatorId == userService.User.UserId || userService.User.Role == ReadMyRoles.Admin), cancellationToken);

            if (taskunit is null)
            {
                throw new BusinessException(TaskunitMessages.TaskunitNotFound);
            }

            foreach (var log in taskunit.Logs)
            {
                context.Remove(log);
            }

            context.Remove(taskunit);

            await context.SaveChangesAsync(cancellationToken);

            return new DeleteEntityResponse(taskunit.Id);
        }
    }
}
