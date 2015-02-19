using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelCalendar
{
    public static class GenerateExcel
    {
        private static string[] months = new string[12] {"January", "February", "March", "April", "May", "June", "July", "August", "September", "Oktober", "November", "December" };
        public static void generate(string filePath)
        {
            Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            if (xlApp == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
                return;
            }

            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            setTitle(xlWorkSheet);

            setMonths(xlWorkSheet);
            setDatesOfMonth(xlWorkSheet);

            xlWorkBook.SaveAs(filePath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

            MessageBox.Show(filePath.ToString() + " created.");
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
            xlWorkSheet.Cells[1, 1] = "Calendar " + Options.year.ToString();
            xlWorkSheet.Cells[1, 1].Font.Size = 30;
            xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[1, 48]].Merge();
        }

        private static void setMonths(Excel.Worksheet xlWorkSheet)
        {
            for (int i = 0; i < 12; i++)
            {
                xlWorkSheet.Range[xlWorkSheet.Cells[2, (i * 4) + 1], xlWorkSheet.Cells[2, (i + 1) * 4]].Merge();
                xlWorkSheet.Cells[2, (i * 4) + 1] = months[i];
            }
        }

        private static void setDatesOfMonth(Excel.Worksheet xlWorkSheet)
        {
            for (int i = 0; i < 12; i++)
            {
                int daysCount = System.DateTime.DaysInMonth(Options.year, i + 1);
                for (int j = 1; j < 32; j++)
                {
                    if (j <= daysCount)
                    {
                        xlWorkSheet.Cells[2 + j, (i * 4) + 1] = j;
                    }
                    else
                    {
                        xlWorkSheet.Range[xlWorkSheet.Cells[2 + j, (i * 4) + 1], xlWorkSheet.Cells[2 + j, (i * 4) + 1]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                    }
                }
                xlWorkSheet.Columns[(i * 4) + 1].AutoFit();
            }
        }
    }
}
