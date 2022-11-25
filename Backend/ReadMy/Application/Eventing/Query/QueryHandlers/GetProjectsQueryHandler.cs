using Application.Eventing.Query.Querys;
using Application.Eventing.Query.ViewModels;

using Common.Authorization;

using Infrastructure;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace Application.Eventing.Query.QueryHandlers
{
    public class GetProjectsQueryHandler : IRequestHandler<GetProjectsQuery, ProjectsListViewModel>
    {
        private readonly ReadMyDbContext _context;
        private readonly ICurrentUserService _userService;

        public GetProjectsQueryHandler(ReadMyDbContext context, ICurrentUserService userService)
        {
            _context = context;
            _userService = userService;
        }
        public async Task<ProjectsListViewModel> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = await _context.Projects
                .Where(x => _userService.User.Role == ReadMyRoles.Admin || (x.Participants.Any(p => p.Id == _userService.User.UserId) || x.Creator.Id == _userService.User.UserId))
                .Select(x => new ProjectViewModel(x.Id, x.Name, x.Description, x.Creator.FullName, x.CreationDate, x.Participants.Select(x => x.FullName).ToList()))
                .ToListAsync(cancellationToken);

            return new ProjectsListViewModel(projects);
        }
    }
}
