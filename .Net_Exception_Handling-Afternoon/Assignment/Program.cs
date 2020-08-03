using System;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Assignment
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            Boolean flag = true;
            log.Info("Program Started Executing");

            //Please change the path of the text file to test execution

            string path ="A:\\SampleText.txt";  //Execution 1
            //string path = "A:\\SaleText.txt"; //Execution 2
            try
            {
                // Trying to Read the content of the File and Writing it on the console
                string text = File.ReadAllText(path);
                Console.WriteLine("\n==================================File Content=========================================\n");
                Console.WriteLine(text);
                Console.WriteLine("\n=======================================================================================\n");

            }
            catch (DirectoryNotFoundException e)
            {
                flag = false;
                Console.WriteLine("\nDirectory Not Found\n");
                log.Error(e.StackTrace);
            }
            catch(FileNotFoundException e)
            {
                flag = false;
                Console.WriteLine("\nFile Not Found\n");
                log.Error(e.StackTrace);
            }
            catch(FileLoadException e)
            {
                flag = false;
                Console.WriteLine("\nFile Could Not Be Loaded\n");
                log.Error(e.StackTrace);
            }
            catch (IOException e)
            {
                flag = false;
                Console.WriteLine("\nAn Input Output Error has occured\n");
                log.Error(e.StackTrace);
            }
            catch(Exception e)
            {
                flag = false;
                Console.WriteLine("\nAn Unexpected Error has occured\n");
                log.Fatal(e.StackTrace);
            }
            finally
            {
                // This block always executes
                if(flag)
                {
                    Console.WriteLine("\n\n");
                    log.Info("File Read Successfully");
                }
                else
                {
                    Console.WriteLine("\n\n");
                    log.Warn("File Read Failed");
                }
                log.Info("Program Execution Ended\n\n");
            }
        }
        
    }
}

