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
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine($"File {file} doesn't contain enough data. {ex.Message}" );
                }
            }
        }
    }
    internal class Program
    {
        static void Main()
        { 
        
        }
    }
}