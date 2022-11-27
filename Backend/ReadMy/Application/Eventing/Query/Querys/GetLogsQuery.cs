using Application.Eventing.Query.ViewModels;

using MediatR;

namespace Application.Eventing.Query.Querys
{
    public class GetLogsQuery : IRequest<LogsListViewModel>
    {
        public GetLogsQuery(string taskId)
        {
            TaskId = taskId;
        }

        public string TaskId { get; }
    }
}
