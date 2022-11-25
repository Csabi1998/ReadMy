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
    public class AddProjektParticipantCommandHandler : IRequestHandler<AddProjektParticipantCommand, UpdateEntityResponse>
    {
        private readonly ReadMyDbContext _context;
        private readonly ICurrentUserService _userService;

        public AddProjektParticipantCommandHandler(ReadMyDbContext context, ICurrentUserService userService)
        {
            _context = context;
            _userService = userService;
        }
        public async Task<UpdateEntityResponse> Handle(AddProjektParticipantCommand request, CancellationToken cancellationToken)
        {
            var projekt = await _context.Projects
                .Include(x => x.Participants)
                .SingleOrDefaultAsync(x => x.Id == request.Dto.ProjektId, cancellationToken);

            if (projekt is null)
            {
                throw new BusinessException(ProjektMessages.ProjektNotFound);
            }

            if(projekt.CreatorId != _userService.User.UserId) 
            {
                throw new BusinessException(ProjektMessages.ProjektModifyOnlyCreator);
            }

            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == request.Dto.UserId, cancellationToken);

            if (user is null)
            {
                throw new BusinessException(UserMessages.UserNotFound);
            }

            projekt.Participants.Add(user);
            
            await _context.SaveChangesAsync(cancellationToken);

            return new UpdateEntityResponse();
        }
    }
}
