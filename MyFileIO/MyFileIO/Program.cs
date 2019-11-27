using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFileIO
{
    class Program
    {
        static void Main(string[] args)
        {
            //Examine File Static Class
            //TestFileClass();

            //Examine Directory Static Class
            //DirectoryClassDemo();

            //Use StreamReader
            //NumberAnalizer("./numbers.txt");

            //Use StreamWriter
            //NoteTaker("../../CSNotes.txt");
            NoteTakerV2("../../CSNotes2.txt");

        }

        /*This method will examin the File Class.
         * Relative Path vs absolute path
         */

        static void TestFileClass()
        {
            //Examine File Static Class
            string fileName = "test.txt";
            GetFileDetails(fileName);

            //absolute path
            fileName = @"C:\test\test2.txt";
            GetFileDetails(fileName);

            //relative path
            //parent directory: ../
            fileName = "../parent1.txt";
            GetFileDetails(fileName);
            fileName = "../../parent2.txt";
            GetFileDetails(fileName);
            //subdirectory
            fileName = "./sub1/sub1.txt";
            GetFileDetails(fileName);

            fileName = "./sub1/sub2/sub2.txt";
            GetFileDetails(fileName);
        }

        static void GetFileDetails(string fileName)
        {
            Console.WriteLine("******");
            if (File.Exists(fileName))
            {
                Console.WriteLine("File Name:\t{0}", fileName);
                Console.WriteLine("Attributes:\t{0}", File.GetAttributes(fileName));
                Console.WriteLine("Creation Time:\t{0}", File.GetCreationTime(fileName));
                Console.WriteLine("Last Access Time:\t{0}", File.GetLastAccessTime(fileName));
                Console.WriteLine("File Content:\n");
                Console.WriteLine(File.ReadAllText(fileName));
            }
            else
            {
                Console.WriteLine("File does not exist");
            }

        }

        /*This method will examin the Directory Class.
        * 
        */
        static void DirectoryClassDemo()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            Console.WriteLine("Currenr Directory:" + currentDirectory);

            currentDirectory += "/SubDirectory";
            //currentDirectory = "./SubDirectory";
            if (!Directory.Exists(currentDirectory))
            {
                Directory.CreateDirectory(currentDirectory);
            }

            string file = currentDirectory + "/demo.txt";

            File.AppendAllText(file, "Hello World..1\n");
            File.AppendAllText(file, "Hello World..2\n");
            File.AppendAllText(file, "Hello World..3\n");


            //get all directories in c
            string directory = @"c:\";
            foreach (string dir in Directory.GetDirectories(directory))
            {
                Console.WriteLine(dir);
            }

            directory = @"E:\Carlos";
            foreach (string fileName in Directory.GetDirectories(directory))
            {

            }
        }

        /* Read from the provide file all the available number and save then into a list.
         * Find the min, max and average
         */

        static void NumberAnalizer(string fileName)
        {
            //Step 1: check if the file is there.
            if (File.Exists(fileName))
            {
                //Step 2: variable
                StreamReader streamReader = null;
                string currentLine;
                List<int> listOfNumbers = new List<int>();
                int min = int.MaxValue, max = int.MinValue;
                int number;
                int sum = 0;
                //Step 3:
                try
                {
                    //Step 4: open stream
                    using (streamReader = new StreamReader(fileName))
                    {
                        //Step 5: read from the file
                        Console.WriteLine("Access file: ");
                        while ((currentLine = streamReader.ReadLine()) != null)
                        {
                            Console.Write(currentLine + ",");
                            //Add to the list only the value that can be parse
                            if (int.TryParse(currentLine, out number))
                            {
                                listOfNumbers.Add(number);
                                //if (number < min)
                                //{
                                //    min = number;
                                //}
                                //if (number > max)
                                //{
                                //    max = number;
                                //}

                                min = number < min ? number : min;
                                max = number > max ? number : max;
                                sum += number;

                            }
                        }

                        Console.WriteLine(
                            "\nThere {0} numbers in the file. \n" +
                            "Min value = \t" + min + "\n" +
                            "Max value = \t" + max + "\n" +
                            "Sum value = \t" + sum + "\n" +
                            "Avg value = \t" + (sum / listOfNumbers.Count).ToString("n2"), listOfNumbers.Count
                            );
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
            else
            {
                Console.WriteLine("Provided file does not exist");
            }
        }

        static void NoteTaker(string noteFile)
        {
            Console.WriteLine("Welcome to the NoteTaker App.");
            StreamWriter streamWriter = null;
            string note;
            int count = 0;

            try
            {
                streamWriter = new StreamWriter(noteFile, true);
                Console.WriteLine("Enter a note (q to quit)");
                note = Console.ReadLine();

                while (note.ToLower() != "q")
                {
                    streamWriter.WriteLine(note);
                    Console.WriteLine("Enter a note (q to quit)");
                    note = Console.ReadLine();
                    count++;
                }

                streamWriter.WriteLine("{0} notes added on {1}.", count, DateTime.Now);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally{
                if (streamWriter != null)
                {
                    streamWriter.Close();
                }

            }
        }

        static void NoteTakerV2(string noteFile)
        {
            Console.WriteLine("Welcome to the NoteTaker App.");
            StreamWriter streamWriter = null;
            string note;
            StringBuilder FullNote = new StringBuilder();
            int count = 0;

            try
            {
                Console.WriteLine("Enter a note (q to quit)");
                note = Console.ReadLine();

                while (note.ToLower() != "q")
                {
                    FullNote.AppendLine(note);
                    Console.WriteLine("Enter a note (q to quit)");
                    note = Console.ReadLine();
                    count++;
                }
                FullNote.AppendLine(string.Format("{0} notes added on {1}.", count, DateTime.Now));

                using (streamWriter = new StreamWriter(noteFile, true))
                {
                    streamWriter.WriteLine(FullNote.ToString());

                }


            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

        }

    }
}
