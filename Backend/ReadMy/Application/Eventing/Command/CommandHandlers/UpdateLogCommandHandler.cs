using Application.Constants;
using Application.Eventing.Command.Commands;
using Application.Eventing.Command.Response;

using Common.Exceptions;

using Infrastructure;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace Application.Eventing.Command.CommandHandlers
{
    public class UpdateLogCommandHandler : IRequestHandler<UpdateLogCommand, UpdateLogResponse>
    {
        private readonly ReadMyDbContext context;

        public UpdateLogCommandHandler(ReadMyDbContext context)
        {
            this.context = context;
        }
        public async Task<UpdateLogResponse> Handle(UpdateLogCommand request, CancellationToken cancellationToken)
        {
            var log = await context.Logs.SingleOrDefaultAsync(x => x.Id == request.Dto.Id, cancellationToken);

            if (log is null)
            {
                throw new BusinessException(LogMessages.LogNotFound);
            }

            log.Modify(
                request.Dto.WorkingHours,
                request.Dto.Name,
                request.Dto.Description,
                request.Dto.Type);

            await context.SaveChangesAsync(cancellationToken);

            return new UpdateLogResponse();
        }
    }
}
