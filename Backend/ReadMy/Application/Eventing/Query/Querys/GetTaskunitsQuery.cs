
using Application.Eventing.Query.ViewModels;

using MediatR;

namespace Application.Eventing.Query.Querys
{
    public class GetTaskunitsQuery : IRequest<TaskunitsListViewModel>
    {
        public GetTaskunitsQuery(string projectId)
        {
            ProjectId = projectId;
        }

        public string ProjectId { get; }
    }
}
