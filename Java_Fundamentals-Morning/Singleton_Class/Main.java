package com.singleton;

//======================Thread-Unsafe Singleton Class======================

class Singleton{
    private static Singleton instance=null;

    private Singleton(){
    }
    public static Singleton getInstance(){
        if(instance==null)
        {
            instance=new Singleton();
        }
        return instance;
    }

}

//=========Creating 2 Objects of a Thread-Unsafe Singleton with Cloning========

class Singleton_Clone implements Cloneable {
    private static Singleton_Clone instance = null;
    private Singleton_Clone() {
    }
    public static Singleton_Clone getInstance() {
        if(instance==null)
        {
            instance = new Singleton_Clone();
        }
        return instance;
    }
    // This method can create 2 objects of a Singleton class
    @Override
    protected Object clone() throws CloneNotSupportedException {
        return super.clone();
    }
}


//=================Thread-Safe Singleton with Double Locking==================

class SingletonThreadSafe{

    private static volatile SingletonThreadSafe object=null;
    private static Object mutex=new Object();
    private SingletonThreadSafe(){
    }
    public static SingletonThreadSafe getSingletonThreadSafe(){
        SingletonThreadSafe instance=object;
        if(instance==null)
        {
            synchronized (mutex)
            {
                instance=object;
                if(instance==null)
                    object=instance=new SingletonThreadSafe();
            }
        }
        return instance;
    }
}

//===============================================================================

public class Main {

    public static void main(String[] args) throws CloneNotSupportedException {

        System.out.println("[Demonstrating a Simple Thread Unsafe Singleton Class]");
        Singleton object_1 =Singleton.getInstance();
        Singleton object_2 =Singleton.getInstance();
        Singleton object_3 =Singleton.getInstance();
        System.out.println("3 Different Objects of Singleton Class");
        System.out.println("Object 1: "+object_1);
        System.out.println("Object 2: "+object_2);
        System.out.println("Object 3: "+object_3);


        //Creating another object using cloning
        System.out.println("\n\n[Demonstrating How to Create Different Objects of a Simple Thread Unsafe Singleton Class using Cloning]");
        Singleton_Clone object_4 =Singleton_Clone.getInstance();
        Singleton_Clone object_5 =(Singleton_Clone) object_4.clone();

        System.out.println("2 Different Objects of a Singleton Class Created using Cloning");
        System.out.println("Object 4: "+object_4);
        System.out.println("Object 5: "+object_5);

    }
}
