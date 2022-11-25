namespace Common.Interfaces
{
    public interface IExcelService
    {
        byte[] GetExcelData(List<string[]> datas);
    }
}
