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
    public class GetLogQueryHandler : IRequestHandler<GetLogQuery, LogViewModel>
    {
        private readonly ReadMyDbContext _context;

        public GetLogQueryHandler(ReadMyDbContext context)
        {
            _context = context;
        }
        public async Task<LogViewModel> Handle(GetLogQuery request, CancellationToken cancellationToken)
        {
            var log = await _context.Logs
                .Where(x => x.Id == request.Id)
                .Select(x => new LogViewModel(x.Id, x.WorkingHours, x.CreationDate, x.Name, x.Description, x.Type, x.Creator.FullName))
                .SingleOrDefaultAsync(cancellationToken);

            if(log == null) 
            {
                throw new BusinessException(LogMessages.LogNotFound);
            }

            return log;
        }
    }
}
