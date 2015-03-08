using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelCalendar
{
    class Person : IPerson
    {
        public string forename { get; set; }
        public string lastname { get; set; }
        public DateTime birthday { get; set; }

        public Person(string forename, string lastname, DateTime birthday)
        {
            this.forename = forename;
            this.lastname = lastname;
            this.birthday = birthday;
        }
    }
}
