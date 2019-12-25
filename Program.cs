using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            //TASK 1
            Console.WriteLine("\n --------TASK 1-------- \n");
            string input, fileName;
            Employee empl = new Employee(new Person("Ivan", "Ivanov", new DateTime(1990, 10, 3)), "DeveloperC++", TimeWork.Free, 1000);
            Employee emplCopy = new Employee();
            Console.WriteLine("Input education (name of organization, qualification, date): ");
            input = Console.ReadLine();
            empl.AddFromConsole(input);
            Console.WriteLine(empl.ToString());
            emplCopy = empl.DeepCopy();
            Console.WriteLine("Copy employee: ");
            Console.WriteLine(emplCopy.ToString());

            //TASK 2
            Console.WriteLine("\n --------TASK 2-------- \n");
            Console.WriteLine("Input file name: ");
            fileName = Console.ReadLine();
            Employee emplLoad = new Employee();
            FileInfo fInfo = new FileInfo(fileName);
            if (fInfo.Exists)
                emplLoad.Load(fileName);
            else
            {
                FileStream f = File.Create(fileName);
                f.Close();
                empl.Save(fileName);
            }
            Console.WriteLine(emplLoad.ToString());

            //TASK 3
            Console.WriteLine("\n --------TASK 3-------- \n");
            Console.WriteLine(empl.ToString());

            //TASK 4
            Console.WriteLine("\n --------TASK 4-------- \n");
            empl.Save(fileName);
            Console.WriteLine(empl.ToString());
            Console.ReadKey();
        }
    }
}
