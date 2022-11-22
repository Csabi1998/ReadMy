namespace Application.Eventing.Query.ViewModels
{
    public class ProjectsListViewModel
    {
        public ProjectsListViewModel(List<ProjectViewModel> projects)
        {
            Projects = projects;
        }

        public List<ProjectViewModel> Projects { get; }
    }
}
