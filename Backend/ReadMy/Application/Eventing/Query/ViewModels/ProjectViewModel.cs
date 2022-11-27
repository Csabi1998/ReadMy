namespace Application.Eventing.Query.ViewModels
{
    public class ProjectViewModel
    {
        public ProjectViewModel(string id, string name, string description, string creator, DateTime creationDate, List<string> participants)
        {
            Id = id;
            Name = name;
            Description = description;
            Creator = creator;
            CreationDate = creationDate;
            Participants = participants;
        }

        public string Id { get; }
        public string Name { get; }
        public string Description { get; }
        public string Creator { get; }
        public DateTime CreationDate { get; }
        public List<string> Participants { get; }
    }
}
