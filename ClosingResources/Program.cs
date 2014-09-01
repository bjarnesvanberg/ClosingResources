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

            string path = Path.GetTempPath();
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string fullFileName = path + FileName;
            if (!File.Exists(fullFileName))
            {
                File.Create(fullFileName);
            }

            StreamWriter toFile = new StreamWriter(fullFileName);
            
            Write(toFile, "Start of file");

            Console.ReadKey();

            toFile.Close();
        }

        public static void Write(StreamWriter sr, string text)
        {
            Console.WriteLine(text);
            sr.WriteLine(text);
        }
    }
}
