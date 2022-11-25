namespace Application.Eventing.Command.Response
{
    public class CreateTaskunitResponse
    {
        public CreateTaskunitResponse(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
