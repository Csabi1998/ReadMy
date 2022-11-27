using Application.Eventing.Query.Querys;
using Application.Eventing.Query.ViewModels;
using Common.Authorization;
using Common.Interfaces;

using Infrastructure;

using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Eventing.Query.QueryHandlers
{
    public class LogsExcelExportQueryHandler : IRequestHandler<LogsExcelExportQuery, LogsExcelExportViewModel>
    {
        private readonly ReadMyDbContext _context;
        private readonly IExcelService _excelService;
        private readonly ICurrentUserService _userService;

        public LogsExcelExportQueryHandler(ReadMyDbContext context, IExcelService excelService, ICurrentUserService userService)
        {
            _context = context;
            _excelService = excelService;
            _userService = userService;
        }
        public async Task<LogsExcelExportViewModel> Handle(LogsExcelExportQuery request, CancellationToken cancellationToken)
        {
            var logs = await _context.Logs
                .Include(x => x.Task)
                .ThenInclude(x => x.Project)
                .Where(x => x.CreatorId == _userService.User.UserId)
                .ToListAsync(cancellationToken);

            var datas = new List<string[]> { new string[] { "Working hours", "Creation date", "Name", "Description", "Type", "Task", "Project" } };

            foreach (var log in logs)
            {
                datas.Add(new string[]
                {
                    log.WorkingHours.ToString(),
                    log.CreationDate.ToString("yyyy-MM-dd"),
                    log.Name,
                    log.Description,
                    log.Type,
                    log.Task.Name,
                    log.Task.Project.Name
                });
            }

            return new LogsExcelExportViewModel($"Logs-{DateTime.Now.ToString("yyyy-MM-dd")}", _excelService.GetExcelData(datas));
        }
    }
}
