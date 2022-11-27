namespace Application.Eventing.Command.Dtos
{
    public class CreateLogDto
    {
        public CreateLogDto(double workingHours, string name, string description, string type, string taskId)
        {
            WorkingHours = workingHours;
            Name = name;
            Description = description;
            Type = type;
            TaskId = taskId;
        }

        public double WorkingHours { get; }
        public string Name { get; }
        public string Description { get; }
        public string Type { get; }
        public string TaskId { get; }
    }
}
