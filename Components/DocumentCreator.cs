using System;
using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;

namespace StudentsSelector
{

    public class Excel
    {
        public static void AddToExcelFile(string fileName, string Desarrollador, string Facilitador, string Fecha)
        {
            FileInfo fileInfo = new FileInfo(fileName);

            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet;
                if (package.Workbook.Worksheets.Count == 0)
                {
                    worksheet = package.Workbook.Worksheets.Add("Sheet1");
                    // Add headers
                    worksheet.Cells[1, 1].Value = "Desarrollador en vivo";
                    worksheet.Cells[1, 2].Value = "Facilitador";
                    worksheet.Cells[1, 3].Value = "Fecha";
                }
                else
                {
                    worksheet = package.Workbook.Worksheets[0];
                }

                // Find the next empty row
                int row = worksheet.Dimension?.Rows + 1 ?? 2;

                // Add user name and titles
                worksheet.Cells[row, 1].Value = Desarrollador;
                worksheet.Cells[row, 2].Value = Facilitador;
                worksheet.Cells[row, 3].Value = Fecha;

                // Save the file
                package.Save();
            }
        }

         public static void ClearExcelFile(string fileName)
        {
            FileInfo fileInfo = new FileInfo(fileName);

            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                if (package.Workbook.Worksheets.Count > 0)
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                    
                    int rowCount = worksheet.Dimension?.Rows ?? 0;
                    if (rowCount > 1)
                    {
                        worksheet.DeleteRow(2, rowCount - 1);
                    }

                    // Save the changes
                    package.Save();
                }
            }
        }

        // public static void Main()
        // {
        //     Console.WriteLine("Klk ingresa tu nombre");
        //     string? Username = Console.ReadLine();
        //     DateTime now = DateTime.Now;
        //     string formattedDate = now.ToString("yyyy-MM-dd HH:mm:ss");

        //     string name1 = names[random.Next(names.Count)];
        //     string name2 = names[random.Next(names.Count)];

        //     AddToExcelFile("Prueba.xlsx", Username!, name1, name2, formattedDate);

            
        //     // ClearExcelFile("Prueba.xlsx");
        // }
    }
}