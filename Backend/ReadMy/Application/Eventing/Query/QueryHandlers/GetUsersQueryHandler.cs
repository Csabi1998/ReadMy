
using Application.Eventing.Query.Querys;
using Application.Eventing.Query.ViewModels;

using Infrastructure;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace Application.Eventing.Query.QueryHandlers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, UsersListViewModel>
    {
        private readonly ReadMyDbContext _context;

        public GetUsersQueryHandler(ReadMyDbContext context)
        {
            _context = context;
        }
        public async Task<UsersListViewModel> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _context.Users
                .Select(x => new UserViewModel(x.Id, x.UserName, x.FullName))
                .ToListAsync(cancellationToken);

            return new UsersListViewModel(users);
        }
    }
}
