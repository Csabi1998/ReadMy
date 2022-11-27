using Application.Eventing.Query.ViewModels;

using MediatR;

namespace Application.Eventing.Query.Querys
{
    public class GetTaskunitQuery : IRequest<TaskunitViewModel>
    {
        public GetTaskunitQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
