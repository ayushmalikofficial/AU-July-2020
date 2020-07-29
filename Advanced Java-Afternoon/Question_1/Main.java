package com.company;

import java.io.File;
import java.util.Scanner;

class FileCount{


    //Depth: Is used for keeping track of the level of directories and files

    //----------Recursive Function to Count Files and Directories-----------
    int[] File_Counter(File F,String Depth )
    {
        //Current Directory
        System.out.println(Depth+"---D : "+F.getName());
        Depth += "   |";
        File list[] = F.listFiles();

        // For Counting Files and Directory in the Current Directory
        int FileCount =0, DirectoryCount = 0;
        int TotalFileCount =0, TotalDirectoryCount = 0;

        //========================Counter==========================
        for (File object : list) {
            //If object is a Directory
            if(object.isDirectory())
            {
                DirectoryCount++;
                TotalDirectoryCount++;
                // Recursive Call
                int values[];
                values = File_Counter(object,Depth);
                TotalFileCount += values[0];
                TotalDirectoryCount += values[1];

            }
            //If object is a File
            else
            {
                FileCount++;
                TotalFileCount++;
                System.out.println(Depth +"---F : "+ object.getName());
            }
        }
        //========================================================

        System.out.print(Depth+"(File : "+FileCount);
        System.out.println(" ,Directory : "+DirectoryCount+")");
        System.out.print(Depth+"(Total File : "+TotalFileCount);
        System.out.println(" ,Directory : "+TotalDirectoryCount+")");

        return new int[]{TotalFileCount,TotalDirectoryCount};
    }



}

public class Main {


    //-------------------Main Function--------------------

    public static void main(String[] args) {

        Scanner input;
        String path;
        FileCount obj;
        File F;

        input =  new Scanner(System.in);
        System.out.println("Enter path : ");
        path = input.nextLine();
        F = new File(path);
        obj= new FileCount();


        obj.File_Counter(F,"");

    }

}