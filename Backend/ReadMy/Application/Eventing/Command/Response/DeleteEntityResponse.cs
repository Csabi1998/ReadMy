namespace Application.Eventing.Command.Response
{
    public class DeleteEntityResponse
    {
        public DeleteEntityResponse(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
