namespace Application.Eventing.Query.ViewModels
{
    public class TaskunitsListViewModel
    {
        public TaskunitsListViewModel(List<TaskunitViewModel> tasks)
        {
            Tasks = tasks;
        }

        public List<TaskunitViewModel> Tasks { get; }
    }
}
