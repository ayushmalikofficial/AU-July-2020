## Exception Handling ##

The exception handling and logging program can be found in 'Program.cs' file in the project. I have shared the output of 2 executions of the program. The file 'Sample.txt' is the file I try to read. Please make changes to the 'path' variable in the code to the address of your text file. The following are some details about the implementation:
* The file was read using 'ReadAllText()' function. This reads the file as an object, hence we are not concerned with opening and closing of file stream.
* The program tries to capture as many exceptions as possible in various catch blocks.
* For easy demonstration, log4net has been configured to display logs on the console.
* Each time an exception is caught a message is displayed for the user and the stack trace of the error is logged.
* If the file was read succesfully, the finally blocks writes a log message: "File Read Successfully".
* If the file wasn't read succesfully, the finally blocks writes a log message: "File Read Failed".
* We also log the start and end of Program execution.

### Execution 1 ###
This output can be found in 'execution1.png'. It demonstrates a case in which file was read successfully.

### Execution 2 ##
This output can be found in 'execution2.png'. It demonstrates a case in which file was not found. The exception was caught, a message was displayed to the user and its corresponding stack.trace was logged.
