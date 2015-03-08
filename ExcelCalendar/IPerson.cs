using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelCalendar
{
    interface IPerson
    {
        string forename { get; set; }
        string lastname { get; set; }
        DateTime birthday { get; set; }
    }
}
