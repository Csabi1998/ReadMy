namespace Application.Eventing.Query.ViewModels
{
    public class ProjectViewModel
    {
        public ProjectViewModel(string id, string name, string description, ProjectParticipantViewModel creator, DateTime creationDate, List<ProjectParticipantViewModel> participants)
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
        public ProjectParticipantViewModel Creator { get; }
        public DateTime CreationDate { get; }
        public List<ProjectParticipantViewModel> Participants { get; }
    }
}
