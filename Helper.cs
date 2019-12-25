using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Helper:Employee
    {
        public int Compare(Employee e1, Employee e2)
        {
            return e1.Salary.CompareTo(e2.Salary);
        }
    }
}
