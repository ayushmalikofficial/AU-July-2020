# Singleton Class Program #

The file Main.java contains 4 classes:

## Singleton ##
This class is a simple singleton class. It is thread unsafe and is created using a private, static constructor and a function 'getInstance()' which returns the object of the class.

## Singleton_Clone ##
This class is same as the Singleton class above except the fact that a function Object clone() has been added. With the help of this function 2 different objects of this class can be created.

## SingletonThreadSafe ##
This class shows how a singleton class can be made thread safe using synchronization locks.

## Main ##
This class demonstrates the working of Singleton and Singleton_Clone class.