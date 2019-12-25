using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace lab3
{
    delegate void EmployeesChangedHandler<TKey>(object source, EmployeesChangedEventArgs<TKey> args);
    class EmployeeCollection<TKey>
    {
        //public delegate void EmployeeListHandler(object source, EmployeeListHandlerEventArgs args);
        //public event EmployeeListHandler EmployeeAdded;
        //public event EmployeeListHandler EmployeeReplaced;
        public event EmployeesChangedHandler<TKey> EmployeesChanged;
        public string CollectionName { get; set; }
       // private List<Employee> employeeCollection = new List<Employee>();
        private Dictionary<TKey, Employee> employeeDictionary = new Dictionary<TKey, Employee>();
        //public Employee this [int index]
        //{
        //    get
        //    {
        //        return employeeCollection[index];
        //    }
        //    set
        //    {
        //        employeeCollection[index] = value;
        //        if (EmployeeReplaced != null)
        //            EmployeeReplaced(this, new EmployeeListHandlerEventArgs(this.CollectionName, $"Element number {index} was replaced.", index));
        //    }
        //}
        public Employee this[TKey index]
        {
            get
            {
                return employeeDictionary[index];
            }
            set
            {
                employeeDictionary[index].PropertyChanged += PropertyChanged;
                employeeDictionary[index] = value;
                if (EmployeesChanged != null)
                    EmployeesChanged(this, new EmployeesChangedEventArgs<TKey>(this.CollectionName, Update.Replace, "", index));
            }
        }
        //public void AddDefaults()
        //{
        //    employeeCollection.Add(new Employee(new Person("Ivanov", "Ivan", new DateTime(1995, 06, 21)), "Developer", TimeWork.FullTime, 500));
        //    if (EmployeeAdded != null)
        //        EmployeeAdded(this, new EmployeeListHandlerEventArgs(this.CollectionName, "New employee was added.", employeeCollection.Count));
        //    employeeCollection.Add(new Employee(new Person("Petrov", "Petr", new DateTime(1993, 01, 01)), "Project manager", TimeWork.PartTime, 200));
        //    if(EmployeeAdded!=null)
        //        EmployeeAdded(this, new EmployeeListHandlerEventArgs(this.CollectionName, "New employee was added.", employeeCollection.Count));
        //}
        //public void AddEmployees(params Employee[] employees)
        //{
        //    for (int i = 0; i < employees.Length; i++)
        //    {
        //        if (EmployeeAdded != null)
        //            EmployeeAdded(this, new EmployeeListHandlerEventArgs(this.CollectionName, "New employee was added.", employeeCollection.Count));
        //        employeeCollection.Add(employees[i]);
        //    }
        //}
        public void AddEmployee(TKey key, Employee employee)
        {
           employee.PropertyChanged += PropertyChanged;
           employeeDictionary.Add(key, employee);
            if (EmployeesChanged != null)
                EmployeesChanged(this, new EmployeesChangedEventArgs<TKey>(this.CollectionName, Update.Add, "", key));
        }
        //public override string ToString()
        //{
        //    string s = "";
        //    foreach(var c in employeeCollection)
        //        s += c.ToString();
        //    return s;
        //}
        public override string ToString()
        {
            string s = "";
            foreach (var c in employeeDictionary)
            {
                s += c.Key;
                s += "\n";
                s += c.Value.ToString();
                s += "\n";
            }
            return s;
        }
        //public override string ToShortString()
        //{
        //    string s = "";
        //    foreach (var c in employeeCollection)
        //    {
        //        s += c.ToShortString();
        //        s += $"\nEducation: {Education.Count} \nOld organizations: {Organizations.Count}";
        //    }
        //    return s;
        //}
        //public void SortBySecondName()
        //{
        //    employeeCollection.Sort();
        //}
        //public void SortByDate()
        //{
        //    employeeCollection.Sort(new Person());
        //}
        //public void SortBySalary()
        //{
        //    employeeCollection.Sort(new Helper());
        //}
        //public bool Replace(int j, Employee emp)
        //{
        //    if (employeeCollection[j] == null)
        //        return false;
        //    else
        //    {
        //        employeeCollection[j] = emp;
        //        if (EmployeeReplaced != null)
        //            EmployeeReplaced(this, new EmployeeListHandlerEventArgs(this.CollectionName, $"Element number {j} was replaced.", j));
        //        return true;
        //    }
        //}
        public bool Replace(Employee emold, Employee emnew)
        {
            bool b = false;
            foreach (var k in employeeDictionary.Keys)
                if (employeeDictionary[k] == emold)
                {
                    employeeDictionary[k] = emnew;
                    b = true;
                    if (EmployeesChanged != null)
                        EmployeesChanged(this, new EmployeesChangedEventArgs<TKey>(this.CollectionName, Update.Replace, "", k));
                    return b;
                }
            return b;
        }
        public int NumberOfEmployeesWithSalayInRange(int left, int right)
        {
            int k = 0;
            foreach (var empl in employeeDictionary)
                if (Enumerable.Range(left, right).Contains(empl.Value.Salary))
                     k++;
            return k;
        }

        public void PropertyChanged(object source, PropertyChangedEventArgs args)
        {
            Employee empl = (Employee)source;
            TKey key1;
            if (employeeDictionary.ContainsValue(empl))
                foreach (var st in employeeDictionary)
                    if (st.Value.Equals(empl))
                    {
                        key1 = st.Key;
                        if (EmployeesChanged != null)
                            EmployeesChanged(this, new EmployeesChangedEventArgs<TKey>(this.CollectionName, Update.Property, args.PropertyName, key1));
                        break;
                    }
        }

        //public void NotifyProperty(object sender, PropertyChangedEventArgs args)
        //{
        //    Employee empl = (Employee)sender;
        //    TKey key;
        //    if (employeeDictionary.ContainsValue(empl))
        //        foreach (var st in employeeDictionary)
        //        {
        //            if (st.Value.Equals(empl))
        //            {
        //                key = st.Key;
        //                EmployeesChanged?.Invoke(this, new EmployeesChangedEventArgs<TKey>(CollectionName, Update.Property, args.PropertyName, key));
        //                break;
        //            }
        //        }
        //}
    }
}
