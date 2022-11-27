using Application.Eventing.Query.Querys;
using Application.Eventing.Query.ViewModels;

using Common.Authorization;

using Infrastructure;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace Application.Eventing.Query.QueryHandlers
{
    public class GetLogsQueryHandler : IRequestHandler<GetLogsQuery, LogsListViewModel>
    {
        private readonly ReadMyDbContext _context;
        private readonly ICurrentUserService _userService;

        public GetLogsQueryHandler(ReadMyDbContext context, ICurrentUserService userService)
        {
            _context = context;
            _userService = userService;
        }
        public async Task<LogsListViewModel> Handle(GetLogsQuery request, CancellationToken cancellationToken)
        {
            var logs = await _context.Logs
                .Where(x => _userService.User.Role != ReadMyRoles.Worker || x.CreatorId == _userService.User.UserId)
                .Select(x => new LogViewModel(x.Id, x.WorkingHours, x.CreationDate, x.Name, x.Description, x.Type, x.Creator.FullName))
                .ToListAsync(cancellationToken);

            return new LogsListViewModel(logs);
        }
    }
}
