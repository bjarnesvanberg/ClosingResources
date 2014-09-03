using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosingResources
{
    class Program
    {
        static void Main(string[] args)
        {
            const string FileName = "TestingResources.txt";

            // Get the path of the "temp" folder for the current user.
            string path = Path.GetTempPath();
            if (!Directory.Exists(path))
            {
                // If for some reason the returned string is not a valid directory, throw an exception
                throw new Exception(string.Format("The directory '{0}' does not exist."));
            }

            // Create the full file name like this "C:\Users\username\AppData\Local\Temp\TestingResources.txt"
            string fullFileName = path + FileName;
            StreamWriter outputFile;

            if (!File.Exists(fullFileName))
            {
                // If the file does not exits, create it
                outputFile = new StreamWriter( File.Create(fullFileName));
            }
            else
            {
                outputFile = new StreamWriter(fullFileName);
            }
            
            Write(outputFile, "Start of file");

            // Wait for the user to close the program
            Console.WriteLine("Press enter to exit.");
            Console.ReadKey();

            // Close the allocated resource
            outputFile.Close();
        }

        public static void Write(StreamWriter sr, string text)
        {
            Console.WriteLine(text);
            sr.WriteLine(text);
        }
    }
}
