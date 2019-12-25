using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{

    [Serializable]
    class Person: IDateAndCopy, IComparable, IComparer<Person>
    {
        protected string firstName;
        protected string secondName;
        protected DateTime date;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string SecondName
        {
            get { return secondName; }
            set { secondName = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public int YearOfBirthday
        {
            get { return date.Year; }
            set { date = new DateTime(value, Date.Month, Date.Day); }
        }
        public Person(string firstname, string secondname, DateTime date)
        {
            this.FirstName = firstname;
            this.SecondName = secondname;
            this.Date = date;
        }
        public Person()
        {
            this.FirstName = "Ivan";
            this.SecondName = "Ivanov";
            this.Date = new DateTime(2001, 01, 01);
        }
        public override string ToString()
        {
            return $"First Name: {FirstName} \nSecond Name: {SecondName} \nDate of Birthday: {Date.ToShortDateString()}";
        }
        public virtual string ToShortString()
        {
            return $"First Name: {FirstName} \nSecond Name: {SecondName}";
        }
        //public override bool Equals(object obj)
        //{
        //    return this.ToString().Equals(obj.ToString());
        //}
        public static bool operator == (Person p1, Person p2)
        {
            return p1.Equals(p2);
        }
        public static bool operator != (Person p1, Person p2)
        {
            return !p1.Equals(p2);
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public object DeepCopy()
        {
            return new Person(this.FirstName, this.SecondName, this.Date);
        }
        public int CompareTo(Object o)
        {
            Person p = o as Person;
            return this.SecondName.CompareTo(p.SecondName);
        }
        public int Compare(Person p1, Person p2)
        {
            return p1.Date.CompareTo(p2.Date);
        }
    }
}
