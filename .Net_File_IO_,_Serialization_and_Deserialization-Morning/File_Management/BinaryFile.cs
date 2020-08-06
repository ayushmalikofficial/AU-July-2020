using System;
using System.IO;

namespace File_Management
{
    //Exercise 2
    class BinaryFile
    {
        string oldPath; //Path of the Binary File
        string newPath, newPath2; //Path of 2 new Text Files

        //Constructor
        public BinaryFile()
        {
            //Please change oldPath,newPath and newPath2 as per the location of the Files in your system
            oldPath = "A:\\Sample.bin"; //Binary File
            newPath = "A:\\newFiltered.txt"; //Required File with only specific ASCII characters
            newPath2 = "A:\\oldUnFiltered.txt"; //This File is  only used for demonstration and contains all characters from the Binary file 

            //Always create new files
            if (File.Exists(newPath))
            {
                File.Delete(newPath);
            }
            if (File.Exists(newPath2))
            {
                File.Delete(newPath2);
            }
        }
        public void Func()
        {
            using(FileStream file = File.OpenRead(oldPath))
            {
                byte[] data = new byte[file.Length];
                file.Read(data, 0, (int)file.Length);
                file.Close();
                
                using(StreamWriter newFile = new StreamWriter(newPath)) // newFiltered.txt created here
                {
                    using (StreamWriter newFile2 = new StreamWriter(newPath2)) // oldUnFiltered.txt created here
                    {

                        for (int i = 0; i < data.Length; i++)
                        {
                            if ((Convert.ToInt32(data[i]) >= 32) && (Convert.ToInt32(data[i]) <= 127) || (Convert.ToInt32(data[i]) == 10) || (Convert.ToInt32(data[i]) == 13))
                            {
                                //Writing characters with only specific ASCII codes
                                newFile.Write(Convert.ToChar(data[i]));
                            }
                            //Writing all content to a text file for easy demonstration
                            newFile2.Write(Convert.ToChar(data[i]));
                        }
                        newFile.Close();
                        newFile2.Close();

                        //Can be used to display the contents of the files on the console
                        /*Console.WriteLine("==========Content of the given Binary File in Text Format==========\n\n ");
                        string text = File.ReadAllText(newPath2);
                        Console.WriteLine(text);
                        Console.WriteLine("\n==========Content written to the New File in Text Format==========\n ");
                        text = File.ReadAllText(newPath);
                        Console.WriteLine(text);
                         */
                    }
                }
            }
        }

       
    }

}
