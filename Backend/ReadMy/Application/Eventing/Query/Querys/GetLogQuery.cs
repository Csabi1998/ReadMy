using Application.Eventing.Query.ViewModels;

using MediatR;

namespace Application.Eventing.Query.Querys
{
    public class GetLogQuery : IRequest<LogViewModel>
    {
        public GetLogQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
