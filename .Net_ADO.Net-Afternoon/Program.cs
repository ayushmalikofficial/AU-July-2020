using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace AOD_Assignment
{
    //This class connects to the database and provides functions for performing operations on the database
    class AOD
    {
        SqlConnection connection;
        string connectionString;
        SqlDataAdapter adapter;
        DataSet dataSet;


        //Creating a connection to Microsoft SQL Server Database
        public AOD()
        {
            //In order to execute the code, please makenecessary changes to the 'connectionString'
            connectionString = "Data Source=AYUSH-PC;Initial Catalog=Assignment;Integrated Security=True";
            connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            dataSet = new DataSet();
        }

        //This function displays the content of Employee Table
        public void Display_Employee()
        {
            adapter = new SqlDataAdapter("Select * from Employee", connection);
            dataSet = new DataSet();
            adapter.Fill(dataSet);
            if (dataSet != null)
            {
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {

                    Console.WriteLine("Employee ID: " + dataSet.Tables[0].Rows[i]["EmpID"] + " Employee Name:" + dataSet.Tables[0].Rows[i]["EmpName"] + "Department ID: " + dataSet.Tables[0].Rows[i]["DeptID"]);
                }
            }
        }
        //This function displays the content of Department Table
        public void Display_Department()
        {
            adapter = new SqlDataAdapter("Select * from Department", connection);
            dataSet = new DataSet();
            adapter.Fill(dataSet);
            if (dataSet != null)
            {
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {

                    Console.WriteLine("Department ID: " + dataSet.Tables[0].Rows[i]["DeptID"] + " Department Name:" + dataSet.Tables[0].Rows[i]["DeptName"]);
                }
            }
        }
        //This function accpets some details from the user and adds a new Department record using those details and a stored procedure named:'insert_into_department'
        public void Insert_Into_Department()
        {
            string input_deptid, input_deptname;
            Console.WriteLine("\nEnter Department ID (must be greater than 4): ");
            input_deptid=Console.ReadLine();
            Console.WriteLine("\nEnter Department Name: ");
            input_deptname = Console.ReadLine();
            string sqlQuery = "execute insert_into_department " +"'"+input_deptid+"'"  + "," + "'"+input_deptname  +"'"+ ";";
            int rowAffected = 0;
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            rowAffected = command.ExecuteNonQuery();

            if (rowAffected != 0)
            {
                Console.WriteLine("\nData Successfully Inserted\n");
            }
            else
            {
                Console.WriteLine("\nInsertion Failed\n");
            }
        }
        // This function deletes the record of an employee using his/her 'employee id' as input by calling a stored procedure named: 'delete_from_employee '
        public void Delete_From_Employee()
        {
            string input_empid;
            Console.WriteLine("\nEnter Employee ID of the record to be deleted: ");
            input_empid = Console.ReadLine();

            string sqlQuery = "execute delete_from_employee " + "'" + input_empid + "'" + ";";
            int rowAffected = 0;
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            rowAffected = command.ExecuteNonQuery();

            if (rowAffected != 0)
            {
                Console.WriteLine("\nData Deleted Successfully\n");
            }
            else
            {
                Console.WriteLine("\nData Deletion Failed\n");
            }

        }

        
        //This function access the contents of 2 tables using a stored procedure named:'department_of_employees'
        //It displays all the Employees's ID, Name and the Name of the corresponding Department in which they work.
        public void Department_of_Employees()
        {
            string sqlQuery = "execute department_of_employees;";
            adapter = new SqlDataAdapter(sqlQuery, connection);
            dataSet = new DataSet();
            adapter.Fill(dataSet);
            if (dataSet != null)
            {
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    Console.WriteLine("Employee ID: " + dataSet.Tables[0].Rows[i]["EmpID"] + " Employee Name:" + dataSet.Tables[0].Rows[i]["EmpName"] + "Department Name: " + dataSet.Tables[0].Rows[i]["DeptName"]);
                }
            }
        }

        //Destructor closes connection to the database
        ~AOD()
        {
            connection.Close();
        }

    }

    //This classes calls and uses data access functions of the above class 'AOD'
    class Program
    {
        
        //Main Function
        static void Main(string[] args)
        {
          
         
            AOD obj = new AOD();   
            Console.WriteLine("=================Department Table Before Insertion of Record=================\n");
           
            obj.Display_Department();
            obj.Insert_Into_Department();

            Console.WriteLine("\n=================Department Table After Insertion of Record==================\n");
            
            obj.Display_Department();
            
            Console.WriteLine("\n================Employee Table Before Deletion of Record=====================\n");
            
            obj.Display_Employee();
            obj.Delete_From_Employee();
            
            Console.WriteLine("\n================Employee Table After Deletion of Record======================\n");
            obj.Display_Employee();
            
            Console.WriteLine("\n==============Content From Employee and Department Table=====================\n");
            obj.Department_of_Employees();

            Console.WriteLine("\nThe above table shows Employees with the name of the Department in which they work");

        }
    }
}
