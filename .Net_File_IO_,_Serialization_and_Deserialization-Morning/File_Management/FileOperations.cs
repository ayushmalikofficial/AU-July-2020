using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;


namespace File_Management
{
    //Exercise 1
    class FileOperations
    {
        string path; //First File
        string secondpath; //Second File with reversed order of lines as compared to the First File
        public FileOperations()
        {
            string directory_name;
            //Creating new Directory
            Console.WriteLine("Enter Name of Directory you wish to create:");
            directory_name = Console.ReadLine();
            Directory.CreateDirectory("A:\\" + directory_name);
            //First File
            path = "A:\\" + directory_name + "\\Text.txt";
            //Second File
            secondpath = "A:\\" + directory_name + "\\ReverseText.txt";
            
            //Always create new files
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            if (File.Exists(secondpath))
            {
                File.Delete(secondpath);
            }
        }

        //Function which creates a new First File and writes data to it
        private void InputText()
        {
            int no_of_lines;
            string input;
            Console.WriteLine("Enter the No. of Lines you wish to add to the Text file: ");
            no_of_lines = Convert.ToInt32(Console.ReadLine());
            //The First File is created here
            using (StreamWriter file = new StreamWriter(path))
            {
                //Writing data to the First File
                while (no_of_lines > 0)
                {
                    input = Console.ReadLine();
                    file.WriteLine(input);
                    no_of_lines--;
                }
                file.Close();
            }

        }

        //Function which Counts the No. of words in the First File
        private void CountWords()
        {
            string line;
            int no_of_words = 0;
            using (StreamReader file = File.OpenText(path))
            {
                do
                {
                    line = file.ReadLine();
                    if (line != null)
                    {
                        string[] words = line.Split(' ');
                        no_of_words += words.Length;
                    }
                }
                while (line != null);
                file.Close();
               
            }
            Console.WriteLine("Count of words is: " + no_of_words);
        }

        //Function which creates a new Second File and copies the lines of the First File into it in reverse order
        private void CopyReverse()
        {
            using(StreamReader file=File.OpenText(path))
            {
                //New Second File created here
                using(StreamWriter reverse_file=new StreamWriter(secondpath))
                {
                    string data,output_data;
                    Stack<string> stack=new Stack<string>();
                    while((data=file.ReadLine())!=null)
                     {
                        //Pushing content of the First File into a Stack
                        stack.Push(data);
                    }
                    while(stack.Count!=0)
                    {
                        output_data= stack.Pop();
                        //Writing Data to the Second File
                        reverse_file.WriteLine(output_data);
                    }
                    file.Close();
                    reverse_file.Close();
                }
            }
        }
       
        //Function called in Main()
        //It calls all other private functions in a specific order
        public void Func()
        {
            // All 3 functions below are private to ensure a systematic order of execution
            //This also ensures that no file is read from or written into, before its creation
            InputText();
            CountWords();
            CopyReverse();
        }
      
    }

    
}
