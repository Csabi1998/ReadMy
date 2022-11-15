namespace Application.Eventing.Command.Dtos
{
    public class UpdateLogDto
    {
        public UpdateLogDto(string id, double workingHours, string name, string description, string type)
        {
            Id = id;
            WorkingHours = workingHours;
            Name = name;
            Description = description;
            Type = type;
        }

        public string Id { get; set; }
        public double WorkingHours { get; }
        public string Name { get; }
        public string Description { get; }
        public string Type { get; }
    }
}
