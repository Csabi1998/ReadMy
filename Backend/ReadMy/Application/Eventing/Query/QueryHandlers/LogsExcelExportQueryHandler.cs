
using Application.Eventing.Query.Querys;
using Application.Eventing.Query.ViewModels;

using Common.Interfaces;

using Infrastructure;

using MediatR;

namespace Application.Eventing.Query.QueryHandlers
{
    public class LogsExcelExportQueryHandler : IRequestHandler<LogsExcelExportQuery, LogsExcelExportViewModel>
    {
        private readonly ReadMyDbContext _context;
        private readonly IExcelService _excelService;

        public LogsExcelExportQueryHandler(ReadMyDbContext context, IExcelService excelService)
        {
            _context = context;
            _excelService = excelService;
        }
        public async Task<LogsExcelExportViewModel> Handle(LogsExcelExportQuery request, CancellationToken cancellationToken)
        {
            return new LogsExcelExportViewModel($"Logs-{DateTime.Now.ToString("yyyy-MM-dd")}", _excelService.GetExcelData(new List<string[]>() { new string[] { "Teszt", "teszt2" } }));
        }
    }
}
