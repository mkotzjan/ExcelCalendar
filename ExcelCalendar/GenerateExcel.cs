using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Net;
using System.Text.RegularExpressions;
using System.Drawing;
using ExcelCalendar.Interfaces;

namespace ExcelCalendar
{
    public class GenerateExcel : IGenerate
    {
        public GenerateExcel(string filePath, List<IPerson> persons)
        {
            DateTime startTime = DateTime.Now;
            calculateEastern(Options.year);
            week = Options.week;

            Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            if (xlApp == null)
            {
                MessageBox.Show("Excel ist nicht richtig installiert!");
                return;
            }

            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            if (Options.showHoliday)
            {
                getHolidays();
                if (holidays.Count != 6)
                {
                    MessageBox.Show("Beim ermitteln der Ferien ist ein Fehler aufgetreten");
                }
            }
            
            setTitle(xlWorkSheet);
            xlWorkSheet.Range[xlWorkSheet.Cells[2, 1], xlWorkSheet.Cells[33, 48]].Borders.Color = System.Drawing.Color.Black;
            for (int i = 0; i < 12; i++)
            {
                setMonths(xlWorkSheet, i);
                for (int j = 1; j < 32; j++)
                {
                    if (Options.showHoliday)
                    {
                        setHolidays(xlWorkSheet, i, j);
                    }
                    setDaysOfMonth(xlWorkSheet, i, j);
                    //setBorders(xlWorkSheet, i, j);
                    
                    if (Options.showWeek)
                    {
                        setWeek(xlWorkSheet, i, j);
                    }
                    if (Options.showFeast)
                    {
                        setFeastDays(xlWorkSheet, i, j);
                    }
                    Program.form.progressBar.Value = (i * 31) + j;
                    TimeSpan timePassed = DateTime.Now - startTime;
                    double timeRemaining = (timePassed.TotalSeconds / ((i * 31) + j)) * (372 - ((i * 31) + j));
                    Program.form.Text = "Noch " + Convert.ToInt32(timeRemaining).ToString() + " Sekunden";
                    
                }
            }

            foreach (var person in persons)
            {
                var month = person.Birthday.Month-1;
                var day = person.Birthday.Day;
                xlWorkSheet.Cells[day + 2, month * 4 + 3] = person.ToString();
            }

            xlWorkBook.SaveAs(filePath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(0);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
            if (MessageBox.Show(filePath.ToString() + " erstellt.") == DialogResult.OK)
            {
                Program.form.progressBar.Value = 0;
                Program.form.Text = "ExcelKalender";
            }
        }

        private void releaseObject(object obj)
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

        private void setTitle(Excel.Worksheet xlWorkSheet)
        {
            xlWorkSheet.Cells[1, 1] = "Kalender " + Options.year.ToString();
            xlWorkSheet.Cells[1, 1].Font.Size = 30;
            xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[1, 48]].Merge();
        }

        private void setMonths(Excel.Worksheet xlWorkSheet, int i)
        {
            xlWorkSheet.Range[xlWorkSheet.Cells[2, (i * 4) + 1], xlWorkSheet.Cells[2, (i + 1) * 4]].Merge();
            xlWorkSheet.Cells[2, (i * 4) + 1] = months[i];
        }

        private void setBorders(Excel.Worksheet xlWorkSheet, int i, int j)
        {
            xlWorkSheet.Range[xlWorkSheet.Cells[2 + j, (i * 4) + 1], xlWorkSheet.Cells[2 + j, (i + 1) * 4]].Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
            xlWorkSheet.Range[xlWorkSheet.Cells[2 + j, (i * 4) + 1], xlWorkSheet.Cells[2 + j, (i + 1) * 4]].Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
            xlWorkSheet.Range[xlWorkSheet.Cells[2 + j, (i * 4) + 1], xlWorkSheet.Cells[2 + j, (i + 1) * 4]].Borders[Excel.XlBordersIndex.xlDiagonalUp].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
            xlWorkSheet.Range[xlWorkSheet.Cells[2 + j, (i * 4) + 1], xlWorkSheet.Cells[2 + j, (i + 1) * 4]].Borders[Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
        }

        private void setDaysOfMonth(Excel.Worksheet xlWorkSheet, int i, int j)
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

        private void setFeastDays(Excel.Worksheet xlWorkSheet, int i, int j)
        {
            if (i == 0 && j == 1)
            {
                xlWorkSheet.Cells[2 + j, (i * 4) + 3] = "Neujahr";
                xlWorkSheet.Cells[2 + j, (i * 4) + 3].Font.Size = 6;
                xlWorkSheet.Range[xlWorkSheet.Cells[2 + j, (i * 4) + 1], xlWorkSheet.Cells[2 + j, (i * 4) + 4]].Interior.ColorIndex = 53;
            }
            else if (i == 0 && j == 6)
            {
                xlWorkSheet.Cells[2 + j, (i * 4) + 3] = "Hl. Drei\r\nKönige";
                xlWorkSheet.Cells[2 + j, (i * 4) + 3].Font.Size = 6;
                xlWorkSheet.Range[xlWorkSheet.Cells[2 + j, (i * 4) + 1], xlWorkSheet.Cells[2 + j, (i * 4) + 4]].Interior.ColorIndex = 53;
            }
            else if (i + 1 == new DateTime(Options.year, easterMonth, easterDay).AddDays(-2).Month && j == new DateTime(Options.year, easterMonth, easterDay).AddDays(-2).Day)
            {
                xlWorkSheet.Cells[2 + j, (i * 4) + 3] = "Karfreitag";
                xlWorkSheet.Cells[2 + j, (i * 4) + 3].Font.Size = 6;
                xlWorkSheet.Range[xlWorkSheet.Cells[2 + j, (i * 4) + 1], xlWorkSheet.Cells[2 + j, (i * 4) + 4]].Interior.ColorIndex = 53;
            }
            else if (i + 1 == easterMonth && j == easterDay)
            {
                xlWorkSheet.Cells[2 + j, (i * 4) + 3] = "Ostersonntag";
                xlWorkSheet.Cells[2 + j, (i * 4) + 3].Font.Size = 6;
            }
            else if (i + 1 == new DateTime(Options.year, easterMonth, easterDay).AddDays(1).Month && j == new DateTime(Options.year, easterMonth, easterDay).AddDays(1).Day)
            {
                xlWorkSheet.Cells[2 + j, (i * 4) + 3] = "Ostermontag";
                xlWorkSheet.Cells[2 + j, (i * 4) + 3].Font.Size = 6;
                xlWorkSheet.Range[xlWorkSheet.Cells[2 + j, (i * 4) + 1], xlWorkSheet.Cells[2 + j, (i * 4) + 4]].Interior.ColorIndex = 53;
            }
            else if (i + 1 == 5 && j == 1)
            {
                xlWorkSheet.Cells[2 + j, (i * 4) + 3] = "Maifeiertag";
                xlWorkSheet.Cells[2 + j, (i * 4) + 3].Font.Size = 6;
                xlWorkSheet.Range[xlWorkSheet.Cells[2 + j, (i * 4) + 1], xlWorkSheet.Cells[2 + j, (i * 4) + 4]].Interior.ColorIndex = 53;
            }
            else if (i + 1 == new DateTime(Options.year, easterMonth, easterDay).AddDays(39).Month && j == new DateTime(Options.year, easterMonth, easterDay).AddDays(39).Day)
            {
                xlWorkSheet.Cells[2 + j, (i * 4) + 3] = "Christi\r\nHimmelfahrt";
                xlWorkSheet.Cells[2 + j, (i * 4) + 3].Font.Size = 6;
                xlWorkSheet.Range[xlWorkSheet.Cells[2 + j, (i * 4) + 1], xlWorkSheet.Cells[2 + j, (i * 4) + 4]].Interior.ColorIndex = 53;
            }
            else if (i + 1 == new DateTime(Options.year, easterMonth, easterDay).AddDays(50).Month && j == new DateTime(Options.year, easterMonth, easterDay).AddDays(50).Day)
            {
                xlWorkSheet.Cells[2 + j, (i * 4) + 3] = "Pfingstmontag";
                xlWorkSheet.Cells[2 + j, (i * 4) + 3].Font.Size = 6;
                xlWorkSheet.Range[xlWorkSheet.Cells[2 + j, (i * 4) + 1], xlWorkSheet.Cells[2 + j, (i * 4) + 4]].Interior.ColorIndex = 53;
            }
            else if (i + 1 == new DateTime(Options.year, easterMonth, easterDay).AddDays(60).Month && j == new DateTime(Options.year, easterMonth, easterDay).AddDays(60).Day)
            {
                xlWorkSheet.Cells[2 + j, (i * 4) + 3] = "Fronleichnam";
                xlWorkSheet.Cells[2 + j, (i * 4) + 3].Font.Size = 6;
                xlWorkSheet.Range[xlWorkSheet.Cells[2 + j, (i * 4) + 1], xlWorkSheet.Cells[2 + j, (i * 4) + 4]].Interior.ColorIndex = 53;
            }
            else if (i + 1 == 10 && j == 3)
            {
                xlWorkSheet.Cells[2 + j, (i * 4) + 3] = "Tag der\r\ndeutschen Einheit";
                xlWorkSheet.Cells[2 + j, (i * 4) + 3].Font.Size = 6;
                xlWorkSheet.Range[xlWorkSheet.Cells[2 + j, (i * 4) + 1], xlWorkSheet.Cells[2 + j, (i * 4) + 4]].Interior.ColorIndex = 53;
            }
            else if (i + 1 == 11 && j == 1)
            {
                xlWorkSheet.Cells[2 + j, (i * 4) + 3] = "Allerheiligen";
                xlWorkSheet.Cells[2 + j, (i * 4) + 3].Font.Size = 6;
                xlWorkSheet.Range[xlWorkSheet.Cells[2 + j, (i * 4) + 1], xlWorkSheet.Cells[2 + j, (i * 4) + 4]].Interior.ColorIndex = 53;
            }
            else if (i + 1 == 12 && j == 25)
            {
                xlWorkSheet.Cells[2 + j, (i * 4) + 3] = "Erster\r\nWeihnachtsfeiertag";
                xlWorkSheet.Cells[2 + j, (i * 4) + 3].Font.Size = 6;
                xlWorkSheet.Range[xlWorkSheet.Cells[2 + j, (i * 4) + 1], xlWorkSheet.Cells[2 + j, (i * 4) + 4]].Interior.ColorIndex = 53;
            }
            else if (i + 1 == 12 && j == 26)
            {
                xlWorkSheet.Cells[2 + j, (i * 4) + 3] = "Zweiter\r\nWeihnachtsfeiertag";
                xlWorkSheet.Cells[2 + j, (i * 4) + 3].Font.Size = 6;
                xlWorkSheet.Range[xlWorkSheet.Cells[2 + j, (i * 4) + 1], xlWorkSheet.Cells[2 + j, (i * 4) + 4]].Interior.ColorIndex = 53;
            }
        }

        private void setHolidays(Excel.Worksheet xlWorkSheet, int i, int j)
        {
            try
            {
                DateTime now = new DateTime(Options.year, i + 1, j);
                foreach (Tuple<DateTime, DateTime> tuple in holidays)
                {
                    if (now.Ticks >= tuple.Item1.Ticks && now.Ticks <= tuple.Item2.Ticks)
                    {
                        xlWorkSheet.Range[xlWorkSheet.Cells[2 + j, (i * 4) + 1], xlWorkSheet.Cells[2 + j, (i * 4) + 4]].Interior.ColorIndex = 40;
                    }
                }
            }
            catch (Exception)
            {
                
            }
        }

        private void setWeek(Excel.Worksheet xlWorkSheet, int i, int j)
        {
            try
            {
                DateTime now = new DateTime(Options.year, i + 1, j);
                if (now.DayOfWeek != DayOfWeek.Sunday && now.DayOfWeek != DayOfWeek.Saturday)
                {
                    if (week == 0)
                    {
                        xlWorkSheet.Range[xlWorkSheet.Cells[2 + j, (i * 4) + 4], xlWorkSheet.Cells[2 + j, (i * 4) + 4]].Interior.ColorIndex = 38;
                    }
                    else
                    {
                        xlWorkSheet.Range[xlWorkSheet.Cells[2 + j, (i * 4) + 4], xlWorkSheet.Cells[2 + j, (i * 4) + 4]].Interior.ColorIndex = 30;
                    }
                }
                else if (now.DayOfWeek == DayOfWeek.Sunday)
                {
                    if (week == 0)
                    {
                        week = 1;
                    }
                    else
                    {
                        week = 0;
                    }
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
