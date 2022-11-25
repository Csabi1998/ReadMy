namespace Application.Eventing.Command.Response
{
    public class CreateLogResponse
    {
        public CreateLogResponse(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
