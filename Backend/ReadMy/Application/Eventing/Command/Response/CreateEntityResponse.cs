namespace Application.Eventing.Command.Response
{
    public class CreateEntityResponse
    {
        public CreateEntityResponse(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
