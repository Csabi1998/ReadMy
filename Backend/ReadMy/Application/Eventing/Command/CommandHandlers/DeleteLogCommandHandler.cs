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
    public class DeleteLogCommandHandler : IRequestHandler<DeleteLogCommand, DeleteEntityResponse>
    {
        private readonly ReadMyDbContext context;
        private readonly ICurrentUserService userService;

        public DeleteLogCommandHandler(ReadMyDbContext context, ICurrentUserService userService)
        {
            this.context = context;
            this.userService = userService;
        }
        public async Task<DeleteEntityResponse> Handle(DeleteLogCommand request, CancellationToken cancellationToken)
        {
            var log = await context.Logs.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (log is null)
            {
                throw new BusinessException(LogMessages.LogNotFound);
            }

            if (userService.User.Role == ReadMyRoles.Worker && log.CreatorId != userService.User.UserId)
            {
                throw new BusinessException(LogMessages.LogDeleteOnlyCreator);
            }

            context.Remove(log);

            await context.SaveChangesAsync(cancellationToken);

            return new DeleteEntityResponse(log.Id);
        }
    }
}
