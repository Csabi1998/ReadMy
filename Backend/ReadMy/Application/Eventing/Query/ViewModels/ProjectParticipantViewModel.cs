namespace Application.Eventing.Query.ViewModels
{
    public class ProjectParticipantViewModel
    {
        public ProjectParticipantViewModel(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; }
        public string Name { get; }
    }
}
