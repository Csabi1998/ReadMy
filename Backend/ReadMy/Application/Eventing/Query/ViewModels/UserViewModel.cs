namespace Application.Eventing.Query.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(string id, string userName, string name)
        {
            Id = id;
            UserName = userName;
            Name = name;
        }

        public string Id { get; }
        public string UserName { get; }
        public string Name { get; }
    }
}
