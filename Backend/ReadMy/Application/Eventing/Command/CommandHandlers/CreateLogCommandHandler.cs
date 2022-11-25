using Application.Constants;
using Application.Eventing.Command.Commands;
using Application.Eventing.Command.Response;

using Common.Authorization;
using Common.Exceptions;

using Domain.Entities;

using Infrastructure;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace Application.Eventing.Command.CommandHandlers
{
    public class CreateLogCommandHandler : IRequestHandler<CreateLogCommand, CreateLogResponse>
    {
        private readonly ReadMyDbContext context;
        private readonly ICurrentUserService userService;

        public CreateLogCommandHandler(ReadMyDbContext context, ICurrentUserService userService)
        {
            this.context = context;
            this.userService = userService;
        }
        public async Task<CreateLogResponse> Handle(CreateLogCommand request, CancellationToken cancellationToken)
        {
            var taskExist = await context.Taskunits.AnyAsync(x => x.Id == request.Dto.TaskId);

            if (!taskExist) 
            {
                throw new BusinessException(TaskunitMessages.TaskunitNotFound);
            }

            var log = new Log(
                request.Dto.WorkingHours, 
                request.Dto.Name,
                request.Dto.Description, 
                request.Dto.Type,
                userService.User.UserId, 
                request.Dto.TaskId);

            context.Add(log);
            await context.SaveChangesAsync(cancellationToken);

            return new CreateLogResponse(log.Id);
        }
    }
}
