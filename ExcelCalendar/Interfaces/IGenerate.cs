using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExcelCalendar.Interfaces
{
    public class IGenerate
    {
        public int easterDay;
        public int easterMonth;
        public static string[] months = new string[12] { "Januar", "Februar", "März", "April", "Mai", "Juni", "Juli", "August", "September", "Oktober", "November", "Dezember" };
        public static int year;
        public static string website;
        public static List<Tuple<DateTime, DateTime>> holidays = new List<Tuple<DateTime, DateTime>>();
        public static int week;

        public int getWeekNumber(int i, int j)
        {
            DateTime time = new DateTime(Options.year, i + 1, j);
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        public void calculateEastern(int year)
        {
            int g = year % 19;
            int c = year / 100;
            int h = h = (c - (int)(c / 4) - (int)((8 * c + 13) / 25)
                                                + 19 * g + 15) % 30;
            int i = h - (int)(h / 28) * (1 - (int)(h / 28) *
                        (int)(29 / (h + 1)) * (int)((21 - g) / 11));

            int day = i - ((year + (int)(year / 4) +
                          i + 2 - c + (int)(c / 4)) % 7) + 28;
            int month = 3;

            if (day > 31)
            {
                month++;
                day -= 31;
            }

            easterMonth = month;
            easterDay = day;
        }

        public void getHolidays()
        {
            if (year != Options.year)
            {
                WebClient w = new WebClient();
                string url = "http://www.kalenderpedia.de/ferien/ferien-baden-wuerttemberg-" + Options.year + ".html";
                website = w.DownloadString(url);

                MatchCollection matchCollection = Regex.Matches(website, @">([\d]+\.[\d]+\.[\d]+\s-\s[\d]+\.[\d]+\.[\d]+)<\/td>",
                RegexOptions.Singleline);

                foreach (Match m in matchCollection)
                {
                    convertToDate(m.Groups[1].ToString());
                }

            }

            year = Options.year;
        }

        public void convertToDate(string rawDate)
        {
            string[] splitDate = rawDate.Split(new Char[] { '.', ' ' });
            DateTime startDay = new DateTime(Convert.ToInt32("20" + splitDate[2]), Convert.ToInt32(splitDate[1]), Convert.ToInt32(splitDate[0]));
            DateTime endDay = new DateTime(Convert.ToInt32("20" + splitDate[6]), Convert.ToInt32(splitDate[5]), Convert.ToInt32(splitDate[4]));
            holidays.Add(new Tuple<DateTime, DateTime>(startDay, endDay));
        }
    }
}
