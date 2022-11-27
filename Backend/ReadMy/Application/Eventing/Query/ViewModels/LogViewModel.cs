namespace Application.Eventing.Query.ViewModels
{
    public class LogViewModel
    {
        public LogViewModel(string id, double workingHours, DateTime creationDate, string name, string description, string type, string creatorName)
        {
            Id = id;
            WorkingHours = workingHours;
            CreationDate = creationDate;
            Name = name;
            Description = description;
            Type = type;
            CreatorName = creatorName;
        }

        public string Id { get; }
        public double WorkingHours { get; }
        public DateTime CreationDate { get; }
        public string Name { get; }
        public string Description { get;}
        public string Type { get;  }
        public string CreatorName { get; }
    }
}
