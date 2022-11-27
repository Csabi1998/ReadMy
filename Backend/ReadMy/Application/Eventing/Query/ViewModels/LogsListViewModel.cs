namespace Application.Eventing.Query.ViewModels
{
    public class LogsListViewModel
    {
        public LogsListViewModel(List<LogViewModel> logs)
        {
            Logs = logs;
        }

        public List<LogViewModel> Logs { get; }
    }
}
