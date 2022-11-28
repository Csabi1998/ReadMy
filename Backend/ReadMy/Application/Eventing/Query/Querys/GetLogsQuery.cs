using Application.Eventing.Query.ViewModels;

using MediatR;

namespace Application.Eventing.Query.Querys
{
    public class GetLogsQuery : IRequest<LogsListViewModel>
    {
    }
}
