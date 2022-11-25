
using Common.Interfaces;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace Common.Services
{

    public class ExcelService : IExcelService
    {
        public byte[] GetExcelData(List<string[]> datas) 
        {
            var stream = new MemoryStream();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(stream))
            {
                var workSheet = package.Workbook.Worksheets.Add("Tasks");
                var cellsRange = workSheet.Cells.LoadFromArrays(datas);
                FormatDocumet(workSheet, datas.ElementAt(0).Length, datas.Count);
                package.Save();
            }
            stream.Position = 0;

            return stream.ToArray();
        }

        private void FormatDocumet(ExcelWorksheet workSheet, int width, int height)
        {
            for (int rowIndex = 0; rowIndex < height; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < width; columnIndex++)
                {
                    var hColumnChar = columnIndex < 26 ? "" : ((char)((columnIndex / 26) - 1 + 'A')).ToString();
                    var lColumnChar = ((char)(columnIndex % 26 + 'A')).ToString();

                    var cell = workSheet.Cells[$"{hColumnChar}{lColumnChar}{rowIndex + 1}"];

                    if (rowIndex < 2)
                    {
                        cell.Style.Font.Bold = true;
                    }
                    cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
            }

            workSheet.Columns.Width = 35;
            workSheet.Rows.Height = 15;
        }
    }
}
