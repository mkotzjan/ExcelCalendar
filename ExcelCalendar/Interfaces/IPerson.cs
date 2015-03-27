using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelCalendar.Interfaces
{
    public interface IPerson
    {
        string Firstname { get; set; }
        string Lastname { get; set; }
        DateTime Birthday { get; set; }
    }
}
