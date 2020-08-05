using System;
using System.Collections.Generic;
using System.Text;

namespace Delegate_and_Event_Handlers
{
    //Solution for Question 3
    //I will use Delegate and CallBack for passing a function as a parameter to another function
    class CallBack
    {
        public delegate void myDelegate();
        //This Function is passed as an argument to Function 'DisplayMessage' using a delegate
        public void Greeting()
        {
           Console.WriteLine(" I hope you are doing well.");
        }
        //This Function uses Function 'Greeting' as a parameter
        public void DisplayMessage(string name, myDelegate obj)
        {
            Console.Write("Hello "+name);
            obj(); //using Function 'Greeting'
        }
        //This Function is called by Main( ) in Program.cs
        public void FunctionCall()
        {
            string name;
            Console.WriteLine("Enter your Name:");
            name = Console.ReadLine();
            myDelegate obj = Greeting;
            DisplayMessage(name,obj);
        }
    }
}
