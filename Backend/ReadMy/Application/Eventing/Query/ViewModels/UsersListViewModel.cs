namespace Application.Eventing.Query.ViewModels
{
    public class UsersListViewModel
    {
        public UsersListViewModel(List<UserViewModel> users)
        {
            Users = users;
        }

        public List<UserViewModel> Users { get; }
    }
}
