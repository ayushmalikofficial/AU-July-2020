package com.company;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

class StringCounter{

    private ArrayList<String> input_string;

    //Constructor
    StringCounter(ArrayList<String> input_string)
    {
        this.input_string=input_string;
    }
    //Function for counting occurrences of the each string in the list of input strings
    protected void stringCount()
    {
        System.out.print("Input List of String: ");
        for(int i=0;i<input_string.size();i++)
            System.out.print(input_string.get(i)+" ");


        HashMap<String,Integer> counter_map = new HashMap<>();

        for (String i : input_string) {
            Integer current_count = counter_map.get(i);
            counter_map.put(i, (current_count == null) ? 1 : current_count + 1);
        }

        for(Map.Entry<String,Integer> entry:counter_map.entrySet())
        {
            System.out.print("\nCount of '"+entry.getKey()+"' : "+entry.getValue());
        }

    }

}

public class Main {

    public static void main(String[] args) {

        ArrayList<String> input_string=new ArrayList<>();

        //The values have been hard coded for demonstration

        //Initialization of input sting list
        input_string.add("Ayush");
        input_string.add("a");
        input_string.add("i");
        input_string.add("z");
        input_string.add("temp");
        input_string.add("Ayush");
        input_string.add("temp");

        StringCounter obj= new StringCounter(input_string);
        //Counting occurrence of each string in the list of input strings using object of class StringCounter
        obj.stringCount();

    }
}
