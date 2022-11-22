namespace Application.Eventing.Query.ViewModels
{
    public class TaskunitViewModel
    {
        public TaskunitViewModel(string id, string serialNumber, string name, string description, DateTime creationDate, string type, double sumOfLogs)
        {
            Id = id;
            SerialNumber = serialNumber;
            Name = name;
            Description = description;
            CreationDate = creationDate;
            Type = type;
            SumOfLogs = sumOfLogs;
        }

        public string Id { get; }
        public string SerialNumber { get; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime CreationDate { get; }
        public string Type { get; private set; }
        public double SumOfLogs { get; }
    }
}
