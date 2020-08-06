using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

//This single class has all the required methods

namespace LINQ_Assignment
{

    class Assignment
    {
        //====================================Question 1===========================================
        //Question: Write a method which takes a string as input and counts the number of vowels in it

        public void CountVowels()
        {
            string input = "";
            Console.Write("Enter Input String: ");
            input = Console.ReadLine();
            int vowelCount = input.Count(c => "aeiou".Contains(Char.ToLower(c)));
            Console.Write("Number of Vowels: " + vowelCount);
        }


        //====================================Question 2===========================================
        //Question: Create a string array with student names. Return the student names who have a 'ee' in it.

        public void StudentArray()
        {
            Console.WriteLine("Enter the Number of Students: ");
            int n = Convert.ToInt32(Console.ReadLine());
            string[] student = new string[n];
            Console.WriteLine("Enter the Names of the Students: ");
            for (int i = 0; i < n; i++)
            {
                student[i] = Console.ReadLine();
            }
            Console.WriteLine("Students Names with 'ee' in it:");
            IEnumerable<string> result = student.Where(x => x.Contains("ee"));
            foreach (string item in result)
            {
                Console.WriteLine(item);
            }
        }

        //===================================Question 3============================================
        //Question: Join 2 lists using LINQ on common attribute


        //Here, I create 2 object lists: Employee and Department
        //Using Join I display which Employee works for which Department
        class Employee
        {
            public string EmpName { get; set; }
            public int DeptID { get; set; }
        }
        class Department
        {
            public string DeptName { get; set; }
            public int DeptID { get; set; }
        }
        public void ListJoin()
        {
            //The values in this code have been hardcoded for demonstration purpose

            //Creating a list of Employees
            List<Employee> Emp = new List<Employee> {
            new Employee {EmpName="Ayush",DeptID=1},
            new Employee {EmpName="Ekansh",DeptID=2},
            new Employee {EmpName="Madhur",DeptID=1},
            new Employee {EmpName="Nehal",DeptID=3},
            };
            //Creating a list of Departments
            List<Department> Dep = new List<Department> {
            new Department { DeptName = "Computer Science",DeptID=1},
            new Department { DeptName = "Chemistry", DeptID = 2 },
            new Department { DeptName = "Physics", DeptID = 3 }
            };
            //Joining Each Employee with the Department he/she works for
            IEnumerable<string> result = from e in Emp
                                         join d in Dep
                                         on e.DeptID equals d.DeptID
                                         select e.EmpName + "-" + d.DeptName;
            Console.WriteLine("Employees with the their corresponding Department:");
            foreach (string item in result)
            {
                Console.WriteLine(item);
            }

        }


    }

    class Program
    {
        //Main Function
        static void Main(string[] args)
        {
            // Calling the Method for each Question
            Assignment obj = new Assignment();
            Console.WriteLine("============================Question 1===================================\n");
            obj.CountVowels();
            Console.WriteLine("\n\n============================Question 2===================================\n");
            obj.StudentArray();
            Console.WriteLine("\n============================Question 3===================================\n");
            obj.ListJoin();
        }
    }
}