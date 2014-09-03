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

            if (!File.Exists(fullFileName))
            {
                // If the file does not exits, create it
                File.Create(fullFileName).Close(); // Close the stream immediately
            }

            // Open the resource at the top of the using statement
            using (StreamWriter outputFile = new StreamWriter(fullFileName))
            {
                // Access the resource
                Write(outputFile, "Start of file");
            }
            // The resource is released when the using statement is exiting

            // Wait for the user to close the program
            Console.WriteLine("Press enter to exit.");
            Console.ReadKey();

            // Closing the allocated resource is no longer needed
            //outputFile.Close();
        }

        public static void Write(StreamWriter sr, string text)
        {
            Console.WriteLine(text);
            sr.WriteLine(text);
        }
    }
}
