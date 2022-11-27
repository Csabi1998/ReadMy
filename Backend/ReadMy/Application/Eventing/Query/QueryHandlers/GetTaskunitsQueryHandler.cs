using Application.Eventing.Query.Querys;
using Application.Eventing.Query.ViewModels;

using Infrastructure;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace Application.Eventing.Query.QueryHandlers
{
    public class GetTaskunitsQueryHandler : IRequestHandler<GetTaskunitsQuery, TaskunitsListViewModel>
    {
        private readonly ReadMyDbContext _context;

        public GetTaskunitsQueryHandler(ReadMyDbContext context)
        {
            _context = context;
        }
        public async Task<TaskunitsListViewModel> Handle(GetTaskunitsQuery request, CancellationToken cancellationToken)
        {
            var taskunits = await _context.Taskunits
                .Where(x => x.ProjectId == request.ProjectId)
                .Select(x => new TaskunitViewModel(x.Id, x.SerialNumber, x.Name, x.Description, x.CreationDate, x.Type, x.Logs.Sum(l => l.WorkingHours)))
                .ToListAsync(cancellationToken);

            return new TaskunitsListViewModel(taskunits);
        }
    }
}
