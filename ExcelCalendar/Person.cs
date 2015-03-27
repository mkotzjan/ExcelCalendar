using ExcelCalendar.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelCalendar
{
    public class Person : IPerson
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthday { get; set; }

        public Person(string firstname, string lastname, DateTime birthday)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Birthday = birthday;
        }

        public override string ToString()
        {
            return Firstname + " " + Lastname + ", " + Birthday.ToShortDateString();
        }
    }
}
