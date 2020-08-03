using System;

namespace Generics
{
    //A Generic Stack Class of Given Size
    class myStack<T>
    {
        int size;
        T[] a;
        int index;
        //Constructor
        public myStack(int size)
        {
            this.size = size;
            a = new T[size];
            index = -1;
        }
        //Function to add an element to the stack
        public void push(T x)
        {
            if (index < size - 1)
            {
                a[++index] = x;
            }
            else
            {
                Console.WriteLine("Stack is Full");
            }
        }
        //Function to delete an element from the stack
        public T pop()
        {
            if (index == -1)
            {
                //In case if Stack is empty, a message is displayed to the user and the default value is returned
				Console.WriteLine("Stack is empty");
                return default(T);
            }
            else
            {
                index--;
                return a[index + 1];
            }
        }
        //Function that returns the element at the top of the stack
        public T top()
        {
            if (index == -1)
            {
				//In case if Stack is empty, a message is displayed to the user and the default value is returned
			   Console.WriteLine("Stack is empty");
                return default(T);
            }
            else
            {
                return a[index];
            }
        }
        //Function which returns true if the stack is empty
        public Boolean isEmpty()
        {
            if (index == -1)
                return true;
            return false;
        }

    }
	
	
    //A Generic Queue Class of Given Size
    class myQueue<T>
    {
        int size;
        T[] a;
        int front, rear;
        //Constructor
        public myQueue(int size)
        {
            this.size = size;
            a = new T[size];
            front = rear = -1;
        }
        //Function to add an element to the rear of the queue
        public void enqueue(T x)
        {
            if (front == -1)
            {
                front++;
                rear++;
                a[rear] = x;
            }

            else if (rear == size - 1)
            {
                Console.WriteLine("Queue is Full");
            }
            else
            {
                rear++;
                a[rear] = x;

            }
        }
        //Function to remove the element from the front of the queue
        public T dequeue()
        {
            if (front == rear)
            {
                T temp = a[front];
                front = rear = -1;
                return temp;
            }
            else if (front == -1)
            {
				//In case if Queue is empty, a message is displayed to the user and the default value is returned
                Console.WriteLine("Queue is Empty");
                return default(T);
            }
            else
            {
                front++;
                return a[front - 1];
            }
        }
        //Function that returns the element at the front of the queue
        public T top()
        {
            if (front == -1)
            {
				//In case if Queue is empty, a message is displayed to the user and the default value is returned          
				Console.WriteLine("Queue is Empty");
                return default(T);
            }
            else
            {
                return a[front];
            }
        }
        //Function which returns true if the queue is empty
        public Boolean isEmpty()
        {
            if (front == -1)
                return true;
            return false;
        }
    }
	
	
    class Program
    {
        static void Main(string[] args)
        {
			//Creating objects of different data types using Generic Classes
			//Values have been hard-coded for easy demonstration
			
			
			
            Console.WriteLine("The following Stack and Queue operations are performed using Objects of my Generic Stack Class and Queue Class respectively");
            Console.WriteLine("The values have been hard-coded for easy demonstration\n");
            Console.WriteLine("===========================Character Stack=============================\n");
            myStack<char> obj = new myStack<char>(5);
            Console.WriteLine("Stack Size: 5");
            Console.WriteLine("Elements being pushed into the stack: a,b,c,d,e,f");
            obj.push('a');
            obj.push('b');
            obj.push('c');
            obj.push('d');
            obj.push('e');
            obj.push('f');
            Console.WriteLine("Top Element:" + obj.top());
            Console.WriteLine("Element Popped:" + obj.pop());
            Console.WriteLine("Top Element: " + obj.top());
            Console.WriteLine("Is Stack Empty:" + obj.isEmpty());

            Console.WriteLine("\n============================Integer Stack==============================\n");
            myStack<int> obj2 = new myStack<int>(3);
            Console.WriteLine("Stack Size: 3");
            Console.WriteLine("Elements being pushed into the stack: 1,2,3");
            obj2.push(1);
            obj2.push(2);
            obj2.push(3);
            Console.WriteLine("Top Element:" + obj2.top());
            Console.WriteLine("Element Popped:" + obj2.pop());
            Console.WriteLine("Top Element: " + obj2.top());
            Console.WriteLine("Element Popped:" + obj2.pop());
            Console.WriteLine("Top Element: " + obj2.top());
            Console.WriteLine("Element Popped:" + obj2.pop());
            Console.WriteLine("Is Stack Empty:" + obj2.isEmpty());

            Console.WriteLine("\n=============================Double Queue===============================\n");
            myQueue<double> obj3 = new myQueue<double>(4);
            Console.WriteLine("Stack Size: 4");
            Console.WriteLine("Elements being enqueued into the queue: 1.1,2.2,3.3,4.5");
            obj3.enqueue(1.1);
            obj3.enqueue(2.2);
            obj3.enqueue(3.3);
            obj3.enqueue(4.5);

            Console.WriteLine("Front Element:" + obj3.top());
            Console.WriteLine("Element Removed:" + obj3.dequeue());
            Console.WriteLine("Front Element: " + obj3.top());
            Console.WriteLine("Element Removed:" + obj3.dequeue());
            Console.WriteLine("Front Element: " + obj3.top());
            Console.WriteLine("Element Removed:" + obj3.dequeue());
            Console.WriteLine("Is Queue Empty:" + obj3.isEmpty());

            Console.WriteLine("\n============================String Queue===============================\n");
            myQueue<string> obj4 = new myQueue<string>(4);
            Console.WriteLine("Stack Size: 4");
            Console.WriteLine("Elements being enqueued into the queue: Ayush,is,a,good,boy");
            obj4.enqueue("Ayush");
            obj4.enqueue("is");
            obj4.enqueue("a");
            obj4.enqueue("good");
            obj4.enqueue("boy");

            Console.WriteLine("Front Element:" + obj4.top());
            Console.WriteLine("Element Removed:" + obj4.dequeue());
            Console.WriteLine("Front Element: " + obj4.top());
            Console.WriteLine("Element Removed:" + obj4.dequeue());
            Console.WriteLine("Front Element: " + obj4.top());
            Console.WriteLine("Element Removed:" + obj4.dequeue());
            Console.WriteLine("Front Element: " + obj4.top());
            Console.WriteLine("Element Removed:" + obj4.dequeue());
            Console.WriteLine("Is Queue Empty:" + obj4.isEmpty());



        }
    }

}
