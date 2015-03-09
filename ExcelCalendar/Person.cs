using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelCalendar
{
    class Person : IPerson
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public DateTime birthday { get; set; }

        public Person(string firstname, string lastname, DateTime birthday)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.birthday = birthday;
        }
    }
}
