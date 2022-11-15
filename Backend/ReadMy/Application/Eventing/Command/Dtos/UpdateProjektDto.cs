namespace Application.Eventing.Command.Dtos
{
    public class UpdateProjektDto
    {
        public UpdateProjektDto(string id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public string Id { get; }
        public string Name { get; }
        public string Description { get; }
    }
}
