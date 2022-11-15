using Application.Constants;
using Application.Eventing.Command.Commands;
using Application.Eventing.Command.Response;

using Common.Exceptions;

using Infrastructure;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace Application.Eventing.Command.CommandHandlers
{
    public class UpdateTaskunitCommandHandler : IRequestHandler<UpdateTaskunitCommand, UpdateTaskunitResponse>
    {
        private readonly ReadMyDbContext context;

        public UpdateTaskunitCommandHandler(ReadMyDbContext context)
        {
            this.context = context;
        }
        public async Task<UpdateTaskunitResponse> Handle(UpdateTaskunitCommand request, CancellationToken cancellationToken)
        {
            var taskunit = await context.Taskunits.SingleOrDefaultAsync(x => x.Id == request.Dto.Id, cancellationToken);

            if (taskunit is null)
            {
                throw new BusinessException(TaszunitMessages.TaskunitNotFound);
            }

            taskunit.Modify(request.Dto.Name, request.Dto.Description, request.Dto.Type);

            await context.SaveChangesAsync(cancellationToken);

            return new UpdateTaskunitResponse();
        }
    }
}
