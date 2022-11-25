namespace Application.Eventing.Command.Response
{
    public class CreateProjektResponse
    {
        public CreateProjektResponse(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
