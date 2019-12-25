using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace lab3
{
    class TestCollections
    {
        private List<Person> people = new List<Person>();
        private List<string> strings= new List<string>();
        private Dictionary<Person, Employee> peopleAndEmployees = new Dictionary<Person, Employee>();
        private Dictionary<string, Employee> stringsAndEmployees = new Dictionary<string, Employee>();
        public static Employee RefEmployee(int a)
        {
            return new Employee(new Person(a.ToString(), "", new DateTime(1970, 01, 01)), a.ToString(), TimeWork.Free, 1);
        }
        public TestCollections(int a)
        {
            Employee e;
            for (int i = 1; i < a; i++)
            {
                e = RefEmployee(i);
                people.Add(e.EmployeeDate);
                strings.Add(e.EmployeeDate.ToString());
                peopleAndEmployees.Add(e.EmployeeDate, e);
                stringsAndEmployees.Add(e.EmployeeDate.ToString(), e);
            }
        }
        public long FindInPeople(Employee e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            if (!people.Contains(e.EmployeeDate))
                return -1;
            stopwatch.Stop();
            return (long)stopwatch.ElapsedMilliseconds;
        }
        public long FindInStrings(Employee e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            if (!strings.Contains(e.EmployeeDate.ToString()))
                return -1;
            stopwatch.Stop();
            return (long)stopwatch.ElapsedMilliseconds;
        }
        public Stopwatch FindInStringDictionaryKey(Employee e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            if (!stringsAndEmployees.ContainsKey(e.EmployeeDate.ToString()))
                stopwatch.Stop();
            stopwatch.Stop();
            return stopwatch;
        }
        public long FindInStringDictionaryValue(Employee e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            if (!stringsAndEmployees.ContainsValue(e))
                return -1;
            stopwatch.Stop();
            return (long)stopwatch.ElapsedMilliseconds;
        }
        public long FindInPeopleDictionaryKey(Employee e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            if (!peopleAndEmployees.ContainsKey(e.EmployeeDate))
                return -1;
            stopwatch.Stop();
            return (long)stopwatch.ElapsedMilliseconds;
        }
        public long FindInPeopleDictionaryValue(Employee e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            if (peopleAndEmployees.ContainsValue(e) == false)
                return -1;
            stopwatch.Stop();
            return (long)stopwatch.ElapsedMilliseconds;
        }
    }
}
