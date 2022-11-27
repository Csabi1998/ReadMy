using Application.Constants;
using Application.Eventing.Query.Querys;
using Application.Eventing.Query.ViewModels;

using Common.Authorization;
using Common.Exceptions;
using Infrastructure;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace Application.Eventing.Query.QueryHandlers
{
    public class GetProjectQueryHandler : IRequestHandler<GetProjectQuery, ProjectViewModel>
    {
        private readonly ReadMyDbContext _context;
        private readonly ICurrentUserService _userService;

        public GetProjectQueryHandler(ReadMyDbContext context, ICurrentUserService userService)
        {
            _context = context;
            _userService = userService;
        }
        public async Task<ProjectViewModel> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {
            var project = await _context.Projects
                .Where(x => (_userService.User.Role == ReadMyRoles.Admin || (x.Participants.Any(p => p.Id == _userService.User.UserId) || x.Creator.Id == _userService.User.UserId)) && x.Id == request.Id)
                .Select(x => new ProjectViewModel(x.Id, x.Name, x.Description, new ProjectParticipantViewModel(x.Creator.Id, x.Creator.FullName), x.CreationDate, x.Participants.Select(x => new ProjectParticipantViewModel(x.Id, x.FullName)).ToList()))
                .SingleOrDefaultAsync(cancellationToken);

            if (project == null)
            {
                throw new BusinessException(ProjektMessages.ProjektNotFound);
            }

            return project;
        }
    }
}
