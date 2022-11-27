using Application.Constants;
using Application.Eventing.Query.Querys;
using Application.Eventing.Query.ViewModels;
using Common.Exceptions;
using Infrastructure;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace Application.Eventing.Query.QueryHandlers
{
    public class GetTaskunitQueryHandler : IRequestHandler<GetTaskunitQuery, TaskunitViewModel>
    {
        private readonly ReadMyDbContext _context;

        public GetTaskunitQueryHandler(ReadMyDbContext context)
        {
            _context = context;
        }
        public async Task<TaskunitViewModel> Handle(GetTaskunitQuery request, CancellationToken cancellationToken)
        {
            var taskunit = await _context.Taskunits
                .Where(x => x.Id == request.Id)
                .Select(x => new TaskunitViewModel(x.Id, x.SerialNumber, x.Name, x.Description, x.CreationDate, x.Type, x.Logs.Sum(l => l.WorkingHours)))
                .SingleOrDefaultAsync(cancellationToken);

            if(taskunit == null) 
            {
                throw new BusinessException(TaskunitMessages.TaskunitNotFound);
            }

            return taskunit;
        }
    }
}
