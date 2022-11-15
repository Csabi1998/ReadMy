using Application.Constants;
using Application.Eventing.Command.Commands;
using Application.Eventing.Command.Response;

using Common.Exceptions;

using Domain.Entities;

using Infrastructure;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace Application.Eventing.Command.CommandHandlers
{
    public class CreateTaskunitCommandHandler : IRequestHandler<CreateTaskunitCommand, CreateTaskunitResponse>
    {
        private readonly ReadMyDbContext context;
        private readonly IMediator mediator;

        public CreateTaskunitCommandHandler(ReadMyDbContext context, IMediator mediator)
        {
            this.context = context;
            this.mediator = mediator;
        }
        public async Task<CreateTaskunitResponse> Handle(CreateTaskunitCommand request, CancellationToken cancellationToken)
        {
            var projectExist = await context.Projects.AnyAsync(x => x.Id == request.Dto.ProjectId, cancellationToken);

            if (!projectExist)
            {
                throw new BusinessException(ProjektMessages.ProjektNotFound);
            }

            var number = await mediator.Send(new GenerateTaskunitNumberCommand(), cancellationToken);

            var taskunit = new Taskunit(number, request.Dto.Name, request.Dto.Description, request.Dto.Type, request.Dto.ProjectId);

            context.Add(taskunit);
            await context.SaveChangesAsync(cancellationToken);

            return new CreateTaskunitResponse(taskunit.Id);
        }
    }
}
