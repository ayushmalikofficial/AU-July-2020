package com.blocking_queue;


import java.util.LinkedList;
import java.util.List;
import java.util.Scanner;

// Blocking Queue implementation
// For demonstration I have restricted my implementation to a queue of Integer type

class BlockingQueue{

    private List<Integer> queue = new LinkedList();

    private int max_size;// Size limit of the Blocking Queue

    private int number;

    //For capturing execution 'put_count' was used

    //private int put_count;
    //private int take_count;


    // Constructor
    public BlockingQueue(int max_size) {
        this.max_size = max_size;
        number=0;
      //  put_count=100;
      //  take_count=100;

    }
    //Synchronized put() Function
    public synchronized void put() throws InterruptedException {
        while(true)//while(put_count>0)
        {
            // To avoid displaying message multiple times 'if' is used.
            if(this.queue.size() == this.max_size)
            {
                System.out.println("Queue is full. No task is already taken by any of the consumer.");
                while (this.queue.size() == this.max_size) {
                    wait();
                }
            }
            if (this.queue.size()==0) {
                notifyAll();
            }
            number++;
            System.out.println("Producer adding Task "+ number+" to the queue.");
            this.queue.add(number);
            //put_count--;
        }
    }

    //Synchronized Take() Function
    public synchronized void take() throws InterruptedException {
        while(true)//while(take_count>0)
        {
            // To avoid displaying message multiple times 'if' is used.
            if(this.queue.size() == 0)
            {
                System.out.println("Queue is empty. There is no task present in the Queue.");
                while (this.queue.size() == 0) {
                    wait();
                }
            }
            if (this.queue.size()==max_size) {
                notifyAll();
            }
            System.out.println("Consumer "+Thread.currentThread().getName()+" removing Task " +this.queue.remove(0)+" from the queue");
        }
            //take_count--;
    }

}


public class Main {


    public static void main(String[] args) {

        //Configuring Number of Consumer Threads

        System.out.println("Enter the No. of consumer threads you wish to create: ");
        Scanner scanner=new Scanner(System.in);
        Integer n= scanner.nextInt();
        System.out.println("Enter the size of the blocking queue you wish to create: ");
        Integer q_size= scanner.nextInt();
        BlockingQueue blocking_queue = new BlockingQueue(q_size);


        System.out.println("No. of producer thread: 1");
        System.out.println("No. of consumer threads: "+n);

        // Creating and starting one producer thread

        Thread producer=new Thread(()-> {
            try {
                blocking_queue.put();
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        });

        producer.start();

        // Creating and starting multiple consumer threads

        Thread consumer[]=new Thread[n];
        for (int i = 0; i < n; i++) {
            consumer[i]=new Thread(()-> {
                try {
                    blocking_queue.take();
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            });
            consumer[i].start();
        }


    }
}
