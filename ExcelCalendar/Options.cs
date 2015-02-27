using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelCalendar
{
    static class Options
    {
        public static int year = System.DateTime.Now.Year;
        public static bool showFeast = false;
        public static bool showHoliday = false;
        public static bool showWeek = false;
        public static int week = -1;
    }
}
