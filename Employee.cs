using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace lab3
{
    enum TimeWork
    {
        FullTime,
        PartTime,
        Free
    }

    enum Update
    {
        Add,
        Replace,
        Property
    }

    [Serializable]
    class Employee : Person, IDateAndCopy, INotifyPropertyChanged
    {
        
        private string position;
        private TimeWork employment;
        private int salary;
        private List<Diploma> education = new List<Diploma>();
        private List<Experience> organizations = new List<Experience>();
        public event PropertyChangedEventHandler PropertyChanged;
        public Person EmployeeDate
        {
            get { return new Person(this.FirstName, this.SecondName, this.Date); }
            set { FirstName = value.FirstName; SecondName = value.SecondName; Date = value.Date; }
        }
        public string Position
        {
            get { return position; }
            set
            {
                position = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Position"));
            }
        }
        public TimeWork Employment
        {
            get { return employment; }
            set { employment = value; }
        }
        public int Salary
        {
            get { return salary; }
            set
            {
                if (value <= 0 || value > 2000)
                    throw new ArgumentOutOfRangeException("Wrong input! Salary must to be in range from 0 to 2000!");
                else salary = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Salary"));
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Salary"));
            }
        }
        internal List<Diploma>Education
        {
            get { return education; }
            set { education = value; }
        }
        internal List<Experience>Organizations
        {
            get { return organizations; }
            set { organizations = value; }
        }
        public Employee(Person person, string position, TimeWork emploument, int salary) : base(person.FirstName, person.SecondName, person.Date)
        {
            this.EmployeeDate = person;
            this.Position = position;
            this.Employment = employment;
            this.Salary = salary;
        }
        public Employee()
        {
            this.FirstName = "Ivan";
            this.SecondName = "Ivanov";
            this.Date = new DateTime(1995, 01, 01);
            this.Position = "Developer";
            this.Employment = TimeWork.Free;
            this.Salary = 1000;
        }
        public Diploma LastDiploma
        {
            get
            {
                if (Education.Count > 0)
                {
                    Diploma lastDiploma = Education[0];
                    foreach (Diploma diploma in Education)
                        if (lastDiploma.Date < diploma.Date)
                            lastDiploma = diploma;
                    return lastDiploma;
                }
                else return null;
            }
        }
        public virtual void AddDiplomas(params Diploma[] diplomas)
        {
            this.Education.AddRange(diplomas);
        }
        public virtual void AddDiplomas(List<Diploma> diplomas)
        {
            this.Education.AddRange(diplomas);
        }
        public virtual void AddExpariece(params Experience[] organizations)
        {
            this.Organizations.AddRange(organizations);
        }
        public virtual void AddExperiece(List<Experience> organizations)
        {
            this.Organizations.AddRange(organizations);
        }
        public override string ToString()
        {
            string s1 = $"Firstname: {FirstName} \nSecondname: {SecondName} \nDate of birthday: {Date} \nPosition: {Position} \nEmployment: {Employment} \nSalary: {Salary} \nEducation:\n";
            foreach (Diploma diploma in Education)
                s1 = s1 + diploma + "\n ";
            s1 = s1 + "Old organizations: ";
            foreach (Experience exp in Organizations)
                s1 = s1 + exp + "\n ";
            return s1;
        }
        public virtual string ToShortString()
        {
            return $"Firstname: {FirstName} \nSecondname: {SecondName} \nDate of birthday: {Date} \nPosition: {Position} \nEmployment: {Employment} \nSalary: {Salary}";
        }
        //public object DeepCopy()
        //{
        //    Employee empl = new Employee(this.EmployeeDate, this.Position, this.Employment, this.Salary);
        //    foreach (var diploma in Education)
        //        empl.Education.Add(diploma.DeepCopy() as Diploma);
        //    foreach (Experience organization in Organizations)
        //        empl.Organizations.Add(organization.DeepCopy() as Experience);
        //    return empl;
        //}

        public static MemoryStream SerializeToStream(object obj)
        {
            MemoryStream stream = new MemoryStream();
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, obj);
            return stream;
        }

        public static object DeserializeFromStream(MemoryStream stream)
        {
            IFormatter formatter = new BinaryFormatter();
            stream.Seek(0, SeekOrigin.Begin);
            object obj = formatter.Deserialize(stream);
            return obj;
        }

        new public Employee DeepCopy()
        {
            Employee st = new Employee(new Person(firstName, secondName, date), position, employment, salary);
            foreach (Diploma e in Education)
                st.Education.Add(e.DeepCopy() as Diploma);
            foreach (Experience t in Organizations)
                st.Organizations.Add(t.DeepCopy() as Experience);
            MemoryStream stream = SerializeToStream(st);
            Employee newSt = (Employee)DeserializeFromStream(stream);
            return newSt;
        }

        public bool Save(string fileName)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            try
            {
                using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    binFormat.Serialize(fStream, this);
                }
                Console.WriteLine("File was saved.");
                return true;
            }
            catch
            {
                Console.WriteLine("Error...");
                return false;
            }
        }

        public static bool Save(string fileName, Employee obj)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            try
            {
                using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    binFormat.Serialize(fStream, obj);
                }
                Console.WriteLine("File was saved.");
                return true;
            }
            catch
            {
                Console.WriteLine("Error...");
                return false;
            }
        }

        public bool Load(string fileName)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            try
            {
                using (Stream fStream = File.OpenRead(fileName))
                {
                    Employee st = (Employee)binFormat.Deserialize(fStream);
                    this.EmployeeDate = st.EmployeeDate;
                    this.Position = st.Position;
                    this.Salary = st.Salary;
                    this.Organizations = st.Organizations;
                    this.Education = st.Education;
                }
                Console.WriteLine("Loaded!");
                return true;
            }
            catch
            {
                Console.WriteLine("Failed!");
                return false;
            }
        }

        public static bool Load(string fileName, out Employee obj)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            try
            {
                using (Stream fStream = File.OpenRead(fileName))
                {
                    obj = (Employee)binFormat.Deserialize(fStream);
                }
                Console.WriteLine("File was loaded.");
                return true;
            }
            catch
            {
                obj = null;
                Console.WriteLine("Error...");
                return false;
            }
        }

        public bool AddFromConsole(string input)
        {
            if (input.Length == 0)
                return false;

            char[] delimiters = { ',' };
            string[] splitedInput = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            const int fieldsCount = 5;

            if (splitedInput.Length % fieldsCount != 0)
                return false;


            Diploma temp = new Diploma();
            try { temp.OrganizationName = splitedInput[0]; }
            catch { return false; }
            try { temp.Qualification = splitedInput[1]; }
            catch { return false; }
            try
            {
                DateTime dt = new DateTime(Convert.ToInt32(splitedInput[2]), Convert.ToInt32(splitedInput[3]), Convert.ToInt32(splitedInput[4]));
                temp.Date = dt;
            }
            catch { return false; }
            Education.Add(temp);

            return true;
        }

        public IEnumerable<Diploma>DiplomasInLastYears(int n)
        {
            foreach (var diploma in Education)
                if (diploma.Date.Year >= DateTime.Today.Year - n)
                    yield return diploma;
        }

        public IEnumerator<Experience> GetEnumerator()
        {
            foreach (var p in Organizations)
                yield return p;
            foreach (var organization in Organizations)
                yield return organization;
        }

        public string GetKey()
        {
            string myKey;
            myKey = this.FirstName;
            myKey += this.Date.Day.ToString();
            myKey += this.Position;
            return myKey;
        }
    }
}
