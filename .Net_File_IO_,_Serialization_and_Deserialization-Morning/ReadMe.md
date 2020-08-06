# File I/O, Serialization and Deserialization #

The code has 3 important 'cs' files:
* Program.cs: Executing Main() function
* FileOperations.cs: Exercise 1
* BinaryFile.cs: Exercise 2
        
In order for the code to work correctly, please change file paths in both BinaryFile.cs and FileOperations.cs

## Exercise 1 ##
The code for exercise 1 is in a class named FileOperations in FileOperations.cs. 
The output of an execution and the new directory and files created are present in the folder 'Output Files for Exercise 1'.
* The constructor of FileOperations asks the user for a directory's name and creates the directory. 
A new file named 'Text.txt' is created in the newly created directory.
* The user then enters the data on the console which is written to 'Text.txt'.
* Then, another function counts and displays the total number of words in 'Text.txt'.
* Following this, another function creates a new file 'ReverseText.txt'. The content of 'Text.txt' is read line by line and written into 'ReverseText.txt' in such a manner that the order of lines is reversed in the latter.
* The order of execution of these functions is controlled by limiting access to them and only allowing a call to them one after the other.


## Exercise 2 ##
The code for exercise 2 is in a class named BinaryFile in BinaryFile.cs.
The output of an execution and the new files created are present in the folder 'Output Files for Exercise 2'.
The program uses a binary file named 'Sample.bin' and creates 2 new text files:  'newFiltered.txt' and 'oldUnFiltered.txt'.
* newFiltered.txt: This is the required file which contains only those characters from 'Sample.bin' whose ASCII code is in 32 to 127, or 10, or 13.  		
* oldUnFiltered.txt: This file is used for demonstration. It contains all the characters from 'Sample.bin'.

## Program ##
This file contains a class Program. Within this class is the Main() function. It creates objects of classes BinaryFile and FileOperations.
It uses those objects to call functions for implementing the tasks for the exercises. 