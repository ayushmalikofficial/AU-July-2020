package com.phone;


import java.util.Scanner;
import java.util.Stack;

// Phone Interface
interface Phone{

    String getPhoneNo();// Returns own Phone number
    void call(); // Make a Call to a Phone Number input by user
    void call(String phone_number); // Make a call to given phone number
    void reDial(); //Re-Dial the Last Called Number
    void answer(Phone recv); // Answer Call from another Phone Number named 'Recv'
    void callLog(); //Display Call History
    void endCall(); //End Current Call
}

class Mobile extends Telephone{

    Mobile(String phone_no)
    {
        super(phone_no);
    }
    // Additional Functionalities can be added
}


class Telephone implements Phone{

    protected boolean on_call; // Check if No. is busy on another call
    protected String phone_no; // Your Phone No.
    protected Stack<String> call_stack = new Stack<String>(); //Keep Track of Call History

    //Constructor
    Telephone(String phone_no){
        on_call= false;
        this.phone_no=phone_no;
    }

    @Override
    public String getPhoneNo()
    {
        return phone_no;
    }

    //End Current Call
    @Override
    public void endCall()
    {
        //Simulating On-Going Call
        while(true)
        {
            System.out.println("Press E to End Call");
            Scanner scanner= new Scanner(System.in);
            String input= scanner.nextLine();
            if(input.regionMatches(true,0,"E",0,1))
            {
                System.out.println("Call Ended");
                on_call = false;
                break;
            }
        }

    }

    //Accept or Reject Incoming Call
    @Override
    public void answer(Phone recv)
    {
        //Answer only if not busy on another call
        if(!on_call)
        {
            on_call = true;

            //Simulating Ringing unless answered
            while(true)
            {
                System.out.println(recv.getPhoneNo() +" is Calling...");
                System.out.println("Press A: Answer | Press R: Reject ");
                Scanner scanner= new Scanner(System.in);
                String input= scanner.nextLine();
                if(input.matches("R"))
                {
                    System.out.println("Call Rejected");
                    call_stack.push("Rejected: "+recv.getPhoneNo());
                    on_call=false;
                    break;
                }
                else if(input.matches("A"))
                {
                    call_stack.push("Incoming: "+recv.getPhoneNo());
                    System.out.println("Call Connected:"+recv.getPhoneNo());//Assuming No Network Failure
                    endCall();
                    break;
                }
            }
        }
        //If busy on another call then the incoming call will be missed
        else
        {
            System.out.println("Missed A Call");
            call_stack.push("Missed:" +recv.getPhoneNo());
        }

    }


    @Override
    public void call()
    {
        String phone_no_to_dial;
        // Can be on only 1 call at a time
        if(on_call==false)
        {
                Scanner scanner= new Scanner(System.in);
                System.out.print("Enter 10 Digit Phone Number: ");
                phone_no_to_dial= scanner.nextLine();
            if(phone_no_to_dial.length()==10)
            {
                System.out.println("Calling: "+phone_no+"...");
                System.out.println("Call Connected");// Assuming No Network Failure
                call_stack.push("Outgoing: "+phone_no);
                endCall();
            }
            else
            {
                System.out.println("Invalid Phone No.");
            }

        }
        else
        {
            System.out.println("Already on Call");
        }

    }

    //Overloaded call function
    @Override
    public void call(String phone_no_to_dial)
    {
        // Can be on only 1 call at a time
        if(on_call==false)
        {
            System.out.println("Calling: "+phone_no_to_dial+"...");
            System.out.println("Call Connected");// Assuming No Network Failure
            call_stack.push("Outgoing: "+phone_no_to_dial);
            endCall();
        }
        else
        {
            System.out.println("Already on Call");
        }

    }

    //Call last dialled no.
    @Override
    public void reDial()
    {
            if(call_stack.empty())
            {
                System.out.println("No Call Record");
            }
            else
            {
                String last_dialled_no = call_stack.peek();
                call(last_dialled_no);
            }
    }
    //Displaying Call Record
    @Override
    public void callLog()
    {
        System.out.println("Call History: "+call_stack);

    }

}


public class Main {

    public static void main(String[] args) {

    //Assuming both Mobile and Telephone are 10-Digit Numbers
    //Objects are initialized with Hard-Coded values for Demonstration

    Telephone telephone=new Telephone("1125472896");
	Mobile mobile=new Mobile("9810345678");

	System.out.println("[Re-dialling Last-Called Number Functionality]");
	telephone.reDial();
	System.out.println("[Calling a Contact Functionality]");
	telephone.call("8475815987");
	System.out.println("[Answering a Call Functionality]");
	telephone.answer(mobile);
	System.out.println("[Dialling a Number Functionality]");
	telephone.call();
	System.out.println("[Call Log Functionality]");
	telephone.callLog();
    System.out.println("[Re-dialling Last-Called Number Functionality]");
	telephone.reDial();
    }
}
