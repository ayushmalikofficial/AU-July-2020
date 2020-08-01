# Phone #

The program Main.java contains 3 classes and an Interface:

## Phone ##
This interface specifies the following functions:
void call(): Make a Call to a Phone Number input by the user
void call(String phone_number): Make a call to a given phone number [Contact]
void reDial(): Re-Dial the Last Called Number
void answer(Phone recv): Answer Call from another Phone Number named 'Recv'
void callLog(): Display Call History
void endCall(): End Current Call

## Telephone ##
This class implements the phone interface.

## Mobile ##
This class extends the Telephone class.

## Main ##
This class demonstrates the functioning of the above classes using various calls to their functions.

## Assumptions ##
For simplicity it is assumed that both landline and mobile have a 10-Digit number. Strict validations have been avoided. The function 'answer()' receives a call using an object. However, for simplicity the function 'call()' simply deals with Phone numbers as strings.