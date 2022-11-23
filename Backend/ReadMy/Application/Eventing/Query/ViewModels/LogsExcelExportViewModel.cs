namespace Application.Eventing.Query.ViewModels
{
    public class LogsExcelExportViewModel
    {
        public LogsExcelExportViewModel(string name, byte[] bytes)
        {
            Name = name;
            Bytes = bytes;
        }

        public string Name { get; set; }
        public byte[] Bytes { get; set; }
    }
}
