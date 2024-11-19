using System;
using System.Collections.Generic;
namespace labaexceptiontask1
{
    class DoFiles
    {
        private List<string> files;
        private List<string> nofiles;
        private List<string> badData;
        private List<string> overflowData;
        public List<string> Files
        {
            get { return files; }
        }
        public List<string> NoFiles
        {
            get { return nofiles; }
        }
        public List<string> BadData
        {
            get { return badData; }
        }
        public List<string> OverflowData
        {
            get { return overflowData; }
        }
        public DoFiles(List<string> files, List<string> nofiles, List<string> badData, List<string> overflowData)
        {
            this.files = files;
            this.nofiles = nofiles;
            this.badData = badData;
            this.overflowData = overflowData;
        }
        public void ReadFiles()
        {
            foreach (string file in Files)
            {
                try
                {
                    string[] lines = File.ReadAllLines(file);
                    Operations(lines, file);
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine($"File {file} doesn't contain data.{ex.Message}");
                }
                catch (FileNotFoundException ex)
                {
                    NoFiles.Add(file);
                    Console.WriteLine($"File {file} is not found. {ex.Message}");
                }
                catch (FormatException ex)
                {
                    BadData.Add(file);
                    Console.WriteLine($"Bad data: {ex.Message}");
                }
            }
        }
        int sum = 0;
        int count = 0;
        public void Operations(string[] lines, string file)
        {
            try
            {
                int num1 = Convert.ToInt32(lines[0]);
                int num2 = Convert.ToInt32(lines[1]);
                int mult = checked(num1 * num2);
                sum += mult;
                count++;
                Average();
            }
            catch(Exception ex)
            {
                OverflowData.Add(file);
                Console.WriteLine($"Overflow in file {file}: {ex.Message}");

            }
            }
        public double Average()
        {
            return (double)sum / count;
        }
    }
    internal class Program
    {
        static void Main()
        { 
        
        }
    }
}