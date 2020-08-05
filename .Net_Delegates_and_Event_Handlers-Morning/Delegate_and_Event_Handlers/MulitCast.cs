using System;
using System.Collections.Generic;
using System.Text;

namespace Delegate_and_Event_Handlers
{
    //Solution for Question 2
    class MultiCast
    {
        //Delegate
        public delegate void myDelegate(string a, string b);
        //String property of the class
        private string property;
        //Constructor
        public MultiCast()
        {
            property ="";
        }
        //Function 1: Concatenates longer of the 2 string parameters to 'property' variable
        public void Function_1(string a,string b)
        {
            if (a.Length > b.Length)
                property = property + a;
            else
                property = property + b;
        }
        //Function 2: Concatenates longer of the 2 string parameters to 'property' variable
        public void Function_2(string a, string b)
        {
            if (a.Length > b.Length)
                property = property + a;
            else
                property = property + b;

        }
        //This Function is called by Main( ) in Program.cs
        public void FunctionCall()
        {
            string input_1, input_2;
            myDelegate obj;
            //Multicasting the Delegate obj
            obj = Function_1;
            obj += Function_2;
            //Accepting 2 Input Strings from the User
            Console.WriteLine("\nFunction 1\n");
            Console.WriteLine("Enter String 1:");
            input_1 = Console.ReadLine();
            Console.WriteLine("Enter String 2:");
            input_2 = Console.ReadLine();
           //Calling Function 1 and 2 with Delegate obj
            obj(input_1,input_2);
            Console.WriteLine("Value of Property String: "+property);
        }

    }
}
