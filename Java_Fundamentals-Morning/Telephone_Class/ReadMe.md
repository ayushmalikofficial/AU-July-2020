# Phone #

The program Main.java contains 3 classes and an interface.

## Phone ##
This interface specifies the following functions:
* void call(): Make a call to a phone Number input by the user
* void call(String phone_number): Make a call to a given phone number [Contact]
* void reDial(): Redial the last called number
* void answer(Phone recv): Answer call from another phone number named 'Recv'
* void callLog(): Display call history
* void endCall(): End current call

## Telephone ##
This class implements the phone interface.

## Mobile ##
This class extends the Telephone class.

## Main ##
This class demonstrates the functioning of the above classes using various calls to their functions.

## Assumptions ##
For simplicity it is assumed that both landline and mobile have a 10-Digit number. Strict validations have been avoided. The function 'answer()' receives a call using an object. However, for simplicity, the function 'call()' deals with phone numbers as strings.