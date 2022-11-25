namespace Application.Eventing.Command.Dtos
{
    public class UpdateTaskunitDto
    {
        public UpdateTaskunitDto(string id, string name, string description, string type)
        {
            Id = id;
            Name = name;
            Description = description;
            Type = type;
        }

        public string Id { get; set; }
        public string Name { get; }
        public string Description { get; }
        public string Type { get; }
    }
}
