using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Interface
{
    public interface ICounter<T>
    {
        int Count { get; }
        T Get(int index);
    }

    public interface IPersons<T> : ICounter<T>
    {
        void Add(T item);
    }

    public class People<T> : IPersons<T>
    {
        private int size;
        private T[] persons;

        public People()
        {
            size = 0;
            persons = new T[10];
        }

        public int Count { get { return size; } }

        public void Add(T pers)
        {
            persons[size] = pers;
            size++;
        }

        public T Get(int index) { return persons[index]; }
    }

    public class Employee
    {
        public long EmployeeNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double HourlySalary { get; set; }

        public Employee(long number = 0, string fName = "John",
                        string lName = "Doe", double salary = 12.05D)
        {
            EmployeeNumber = number;
            FirstName = fName;
            LastName = lName;
            HourlySalary = salary;
        }

        public override string ToString()
        {
            base.ToString();

            return string.Format("================================\n" +
                                 "Employee Record\n" +
                                 "--------------------------------\n" +
                                 "Employee #:    {0}\nFirst Name:    {1}\n" +
                                 "Last Name:     {2}\nHourly Salary: {3}",
                                 EmployeeNumber, FirstName,
                                 LastName, HourlySalary);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IPersons<Employee> employees = new People<Employee>();

            Employee empl = null;

            empl = new Employee();
            empl.EmployeeNumber = 253055;
            empl.FirstName = "Joseph";
            empl.LastName = "Denison";
            empl.HourlySalary = 12.85;
            employees.Add(empl);

            empl = new Employee();
            empl.EmployeeNumber = 204085;
            empl.FirstName = "Raymond";
            empl.LastName = "Ramirez";
            empl.HourlySalary = 9.95;
            employees.Add(empl);

            empl = new Employee();
            empl.EmployeeNumber = 970044;
            empl.FirstName = "Christian";
            empl.LastName = "Riley";
            empl.HourlySalary = 14.25;
            employees.Add(empl);

            for (int i = 0; i < employees.Count; i++)
            {
                Employee staff = employees.Get(i);

                Console.WriteLine("--------------------------------");
                Console.WriteLine("Employee #:    {0}", staff.EmployeeNumber);
                Console.WriteLine("First Name:    {0}", staff.FirstName);
                Console.WriteLine("Last Name:     {0}", staff.LastName);
                Console.WriteLine("Hourly Salary: {0}", staff.HourlySalary);
            }
        }
    }
    }
