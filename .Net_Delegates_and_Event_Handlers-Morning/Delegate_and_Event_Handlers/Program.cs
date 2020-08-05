using System;

namespace Delegate_and_Event_Handlers
{
    //This Class calls and executes the code for all the questions 
    class Program
    {
        //Subscriber Function for Calculator
        public static void Sum_Subscriber(int a,int b)
        {
            int sum = a + b;
            Console.WriteLine("\nSum is: "+sum);

        }
        //Subscriber Function 2 for Calculator : This Function can be used for Verification of Execution on Event Call
        public static void Subscriber_2(int a,int b)
        {
            Console.WriteLine("\n2nd Subscriber is also called");
        }

        //This Function calls and executes the code for all questions
        static void Main(string[] args)
        {

            //---------------------------Question 1-----------------------------------
            Calculator obj = new Calculator();
            //Subscribing to Event
            obj.EnterPress +=Sum_Subscriber; 
            //Uncomment Line 29 for Verification of Event Handling
            //obj.EnterPress += Subscriber_2; 
            Console.WriteLine("===Question 1===\n");
            obj.StartProcess();

            //---------------------------Question 2-----------------------------------
            Console.WriteLine("\n===Question 2===");
            MultiCast obj2 = new MultiCast();
            obj2.FunctionCall();


            //---------------------------Question 3-----------------------------------
            Console.WriteLine("\n===Question 3===\n");
            CallBack obj3 = new CallBack();
            obj3.FunctionCall();
            //----------------------------------------------------------------------------

        }
    }
}
