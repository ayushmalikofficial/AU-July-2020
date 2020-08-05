using System;
using System.Security.Cryptography;

namespace Delegate_and_Event_Handlers
{
    //Solution for Question 1
    class Calculator
    {
        //My Delegate 
        public delegate void Notify(int a, int b);

        //Event
        public event Notify EnterPress; 

        public void StartProcess()
        {
            //Accepting 2 Numbers from the User
            int input_1, input_2;
            Console.WriteLine("Enter 1st Number: ");
            input_1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter 2nd Number: ");
            input_2 = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("\nPress Enter to Display Sum");
            //Console.Readline() ensures that program continously accepts other input key presses except 'Enter'
            //Only on pressing 'Enter' 'Invoke' is called 
            Console.ReadLine(); 
            
            OnEnterPress(input_1,input_2);
        }
        //Protected Virtual Method
        protected virtual void OnEnterPress(int a,int b) 
        {
            EnterPress?.Invoke(a,b);
        }

    }
    
}
