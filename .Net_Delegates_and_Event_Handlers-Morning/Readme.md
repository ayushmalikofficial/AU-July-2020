# Delegates and Event Handlers #

The code has 4 important 'cs' files:
* Program.cs
* Calculator.cs: Question 1
* MultiCast.cs: Question 2
* CallBack.cs: Question 3  A sample output of execution is presented in Output.png. The folder Delegate_and_Event_Handlers has the Visual Studio Project. Each of the above 4 files have been discussed in detail below.

## Program.cs ##
This file has a class named Program. There are 3 functions in this program:
* Main(): This function calls and executes code for all the questions using objects of Calculator, MultiCast and CallBack class.
* Sum_Subscriber(): This is the subscriber function, subscribed to the event of Calculator class.
* Subscriber_2(): This function is also subscribed to the same event of Calculator class. It can be used for verification and better demonstration of the concept.

## Calculator.cs ##
This file contains a class named Calculator, a publisher. It provides the solution for Question 1. It defines a delegate and an event associated with the delegate.
The subscriber functions in Program class subscribe to the event in Calculator class. 

## MultiCast.cs ##
This file contains a class named MultiCast. This class provides the solution for Question 2 of the assignment. It creates 3 functions: Function_1(), Function_2() and FunctionCall().
Function_1() and Function_2() accept 2 strings and concatenate the longer string to a string named 'property' of class MultiCast. These 2 functions are multi-casted into a delegate.
FunctionCall() implements the multi-casting and displays the result. FunctionCall()is called in Main().

## CallBack.cs ##
This file contains a class named CallBack. This class provides the solution for Question 3 of the assignment. There are 3 functions in the program: Greeting(), DisplayMessage() and FunctionCall().
A delegate is associated with function Greeting(), which is further passed as a parameter to function DisplayMessage().
FunctionCall() creates the delegate and calls function DisplayMessage() with the delegate as one of its parameters. FunctionCall()is called in Main().
