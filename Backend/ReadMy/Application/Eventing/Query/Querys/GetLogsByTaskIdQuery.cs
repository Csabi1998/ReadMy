using Application.Eventing.Query.ViewModels;

using MediatR;

namespace Application.Eventing.Query.Querys
{
    public class GetLogsByTaskIdQuery : IRequest<LogsListViewModel>
    {
        public GetLogsByTaskIdQuery(string taskId)
        {
            TaskId = taskId;
        }

        public string TaskId { get; }
    }
}
