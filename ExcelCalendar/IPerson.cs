using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelCalendar
{
    interface IPerson
    {
        string firstname { get; set; }
        string lastname { get; set; }
        DateTime birthday { get; set; }
    }
}
