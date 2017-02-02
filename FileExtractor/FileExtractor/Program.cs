using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace FileExtractor
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("File Extractor");

            // get file with list of file names 
            Console.WriteLine(Environment.NewLine + "List file:");
            var listFile = Console.ReadLine();
            int lineCount = File.ReadLines(listFile).Count();

            Console.WriteLine(string.Concat(lineCount, " files to copy.", Environment.NewLine));

            // get source directory 
            Console.WriteLine(string.Concat(Environment.NewLine, "Source Directory:"));
            var sourceDir = Console.ReadLine();

            // get target directory 
            Console.WriteLine(string.Concat(Environment.NewLine, "Target Directory"));
            var targetDir = Console.ReadLine();

            Console.WriteLine("{0} {0}", Environment.NewLine);

            var missingFiles = new List<string>();
            int counter = 0;
            string line;

            // Create new stopwatch. 
            var stopwatch = new Stopwatch();

            // Begin timing. 
            stopwatch.Start();

            // Read the file and display it line by line. 
            var file = new System.IO.StreamReader(listFile);
            while ((line = file.ReadLine()) != null)
            {
                if (File.Exists(sourceDir + line))
                {
                    File.Copy(sourceDir + line, targetDir + line, true);
                    //Console.SetCursorPosition(0, Console.CursorTop - 1); 
                    //Console.WriteLine("                                                                                               "); 
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    Console.WriteLine(string.Concat(counter, "/", lineCount));
                    //Console.WriteLine(string.Concat(counter, "/", lineCount, " | ", line, " copied.")); 
                    counter++;
                }
                else
                {
                    missingFiles.Add(line);
                    //Console.SetCursorPosition(0, Console.CursorTop - 1); 
                    //Console.WriteLine(string.Concat(counter, "/", lineCount, " | ", line, " does not exist.")); 
                }
            }

            file.Close();

            // Stop timing. 
            stopwatch.Stop();

            Console.WriteLine(string.Format("{0}Job Complete!{0}{0}", Environment.NewLine));

            // display a report of number of files copied and a list of missing files 
            Console.WriteLine("### Job Report ###" + Environment.NewLine);

            Console.WriteLine(string.Concat(
                lineCount, " files submitted to copy.", Environment.NewLine +
                counter, " files copied.", Environment.NewLine,
                missingFiles.Count(), " files could not be found.", Environment.NewLine
                ));

            Console.WriteLine(string.Concat("Time take to complete job: ", stopwatch.Elapsed, Environment.NewLine));

            Console.WriteLine("List of missing files:");
            missingFiles.ForEach(Console.WriteLine);
            // Suspend the screen. 
            Console.ReadKey();
        }
    }
}