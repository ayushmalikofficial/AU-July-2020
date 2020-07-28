package com.company;

import java.io.File;
import java.util.Scanner;


public class Main {

    //Depth: Is used for keeping track of the level of directories and files


    //----------Recursive Function to Count Files and Directories-----------

    public static int[] File_Counter(File F, String Depth)
    {
        //Current Directory
        System.out.println(Depth+"---D : "+F.getName());

        Depth += "   |";

        File list[] = F.listFiles();

        // For Counting Files and Directory in the Current Directory
        int FileCount =0, DirectoryCount = 0;
        //
        int TotalFileCount =0, TotalDirectoryCount = 0;


        //========================Counter==========================

        for (File object : list) {
            //If object is a Directory
            if(object.isDirectory())
            {
                DirectoryCount++;
                TotalDirectoryCount++;
                // Recursive Call
                int val[] = File_Counter(object,Depth);
                TotalFileCount += val[0];
                TotalDirectoryCount += val[1];

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

    //-------------------Main Function---------------------------

    public static void main(String[] args) {

        Scanner input =  new Scanner(System.in);
        System.out.println("Enter path : ");
        String path = input.nextLine();

        File file = new File(path);
        File_Counter(file,"");
    }

}