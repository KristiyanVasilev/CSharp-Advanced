namespace ExportToExcel
{
    using System;
    using System.Collections.Generic;
    using OfficeOpenXml;
    using System.IO;

    public class ExportToExcel
    {
        public static void Main()
        {
            var xlsPackage = new ExcelPackage();
            var workSheet = xlsPackage.Workbook.Worksheets.Add("Test");
            using (var reader = new StreamReader("../../StudentData.txt"))
            {
                var line = reader.ReadLine();
                var row = 1;
                while (line != null)
                {
                    var colums = line.Split('\t');
                    for (int i = 1; i < colums.Length; i++)
                    {
                        workSheet.Cells[row, i].Value = colums[i - 1];
                    }
                    row++;
                    line = reader.ReadLine();
                }
            }

            var output = new FileStream("../../StudentData.xlsx", FileMode.Create);
            xlsPackage.SaveAs(output);
        }
    }
}
