namespace Application.Eventing.Command.Dtos
{
    public class CreateLogDto
    {
        public CreateLogDto(double workingHours, string name, string description, string type, string creatorId, string taskId)
        {
            WorkingHours = workingHours;
            Name = name;
            Description = description;
            Type = type;
            CreatorId = creatorId;
            TaskId = taskId;
        }

        public double WorkingHours { get; }
        public string Name { get; }
        public string Description { get; }
        public string Type { get; }
        public string CreatorId { get; }
        public string TaskId { get; }
    }
}
