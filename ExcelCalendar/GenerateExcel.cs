using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace ExcelCalendar
{
    public static class GenerateExcel
    {
        private static string[] months = new string[12] {"Januar", "Februar", "März", "April", "Mai", "Juni", "Juli", "August", "September", "Oktober", "November", "Dezember" };
        public static void generate(string filePath)
        {
            Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            if (xlApp == null)
            {
                MessageBox.Show("Excel ist nicht richtig instaliert!");
                return;
            }

            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            setTitle(xlWorkSheet);

            for (int i = 0; i < 12; i++)
            {
                setMonths(xlWorkSheet, i);
                for (int j = 1; j < 32; j++)
                {
                    setDaysOfMonth(xlWorkSheet, i, j);
                }
            }
            
            // setBorders(xlWorkSheet);

            xlWorkBook.SaveAs(filePath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

            MessageBox.Show(filePath.ToString() + " erstellt.");
        }

        private static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private static void setTitle(Excel.Worksheet xlWorkSheet)
        {
            xlWorkSheet.Cells[1, 1] = "Kalender " + Options.year.ToString();
            xlWorkSheet.Cells[1, 1].Font.Size = 30;
            xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[1, 48]].Merge();
        }

        private static void setMonths(Excel.Worksheet xlWorkSheet, int i)
        {
            xlWorkSheet.Range[xlWorkSheet.Cells[2, (i * 4) + 1], xlWorkSheet.Cells[2, (i + 1) * 4]].Merge();
            xlWorkSheet.Cells[2, (i * 4) + 1] = months[i];
        }

        private static void setBorders(Excel.Worksheet xlWorkSheet)
        {
            xlWorkSheet.Range[xlWorkSheet.Cells[2, 1], xlWorkSheet.Cells[33, 48]].Borders.Color = System.Drawing.Color.Black;
        }

        private static void setDaysOfMonth(Excel.Worksheet xlWorkSheet, int i, int j)
        {
            int daysCount = System.DateTime.DaysInMonth(Options.year, i + 1);

            if (j <= daysCount)
            {
                xlWorkSheet.Cells[2 + j, (i * 4) + 1] = j;
                DateTime dt = new DateTime(Options.year, i + 1, j);
                string day = dt.ToString("dddd", DateTimeFormatInfo.CurrentInfo).Substring(0, 2);
                xlWorkSheet.Cells[2 + j, (i * 4) + 2] = day;
                if (day == "Mo")
                {
                    xlWorkSheet.Cells[2 + j, (i * 4) + 4] = getWeekNumber(i, j).ToString();
                    xlWorkSheet.Cells[2 + j, (i * 4) + 4].Font.Size = 6;
                }
                else if (day == "So")
                {
                    xlWorkSheet.Range[xlWorkSheet.Cells[2 + j, (i * 4) + 1], xlWorkSheet.Cells[2 + j, (i * 4) + 4]].Interior.ColorIndex = 53;
                }
                else if (day == "Sa")
                {
                    xlWorkSheet.Range[xlWorkSheet.Cells[2 + j, (i * 4) + 1], xlWorkSheet.Cells[2 + j, (i * 4) + 4]].Interior.ColorIndex = 46;
                }
            }
            else
            {
                xlWorkSheet.Range[xlWorkSheet.Cells[2 + j, (i * 4) + 1], xlWorkSheet.Cells[2 + j, (i + 1) * 4]].Merge();
                xlWorkSheet.Range[xlWorkSheet.Cells[2 + j, (i * 4) + 1], xlWorkSheet.Cells[2 + j, (i * 4) + 1]].Interior.ColorIndex = 15;
            }
            xlWorkSheet.Columns[(i * 4) + 1].AutoFit();
            xlWorkSheet.Columns[(i * 4) + 2].AutoFit();
            xlWorkSheet.Columns[(i * 4) + 4].AutoFit();
        }

        private static int getWeekNumber(int i, int j)
        {
            DateTime time = new DateTime(Options.year, i + 1, j);
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }
    }
}
