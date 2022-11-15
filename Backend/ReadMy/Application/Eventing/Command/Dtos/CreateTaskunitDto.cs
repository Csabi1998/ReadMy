namespace Application.Eventing.Command.Dtos
{
    public class CreateTaskunitDto
    {
        public CreateTaskunitDto(string name, string description, string type, string projectId)
        {
            Name = name;
            Description = description;
            Type = type;
            ProjectId = projectId;
        }

        public string Name { get; }
        public string Description { get; }
        public string Type { get; }
        public string ProjectId { get; }
    }
}
