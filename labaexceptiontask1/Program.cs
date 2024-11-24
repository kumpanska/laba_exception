﻿using System;
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
            catch(OverflowException ex)
            {
                OverflowData.Add(file);
                Console.WriteLine($"Overflow in file {file}: {ex.Message}");

            }
            }
        public double Average()
        {
            return (double)sum / count;
        }
        public void CreateFiles()
        {
            File.WriteAllLines(@"C:\c#labs\labaexceptiontask1\labaexceptiontask1\no_file.txt", NoFiles);
            File.WriteAllLines(@"C:\c#labs\labaexceptiontask1\labaexceptiontask1\bad_data.txt", BadData);
            File.WriteAllLines(@"C:\c#labs\labaexceptiontask1\labaexceptiontask1\overflow.txt", OverflowData);
        }
    }
    internal class Program
    {
        static void Main()
        {
            List<string> files = new List<string>
            {
             @"C:\c#labs\labaexceptiontask1\labaexceptiontask1\TXT\10.txt",
             @"C:\c#labs\labaexceptiontask1\labaexceptiontask1\TXT\11.txt",
             @"C:\c#labs\labaexceptiontask1\labaexceptiontask1\TXT\12.txt",
             @"C:\c#labs\labaexceptiontask1\labaexceptiontask1\TXT\13.txt",
             @"C:\c#labs\labaexceptiontask1\labaexceptiontask1\TXT\14.txt",
             @"C:\c#labs\labaexceptiontask1\labaexceptiontask1\TXT\15.txt",
             @"C:\c#labs\labaexceptiontask1\labaexceptiontask1\TXT\16.txt",
             @"C:\c#labs\labaexceptiontask1\labaexceptiontask1\TXT\17.txt",
             @"C:\c#labs\labaexceptiontask1\labaexceptiontask1\TXT\18.txt",
             @"C:\c#labs\labaexceptiontask1\labaexceptiontask1\TXT\19.txt",
             @"C:\c#labs\labaexceptiontask1\labaexceptiontask1\TXT\20.txt",
             @"C:\c#labs\labaexceptiontask1\labaexceptiontask1\TXT\21.txt",
             @"C:\c#labs\labaexceptiontask1\labaexceptiontask1\TXT\22.txt",
             @"C:\c#labs\labaexceptiontask1\labaexceptiontask1\TXT\23.txt",
             @"C:\c#labs\labaexceptiontask1\labaexceptiontask1\TXT\24.txt",
             @"C:\c#labs\labaexceptiontask1\labaexceptiontask1\TXT\25.txt",
             @"C:\c#labs\labaexceptiontask1\labaexceptiontask1\TXT\26.txt",
             @"C:\c#labs\labaexceptiontask1\labaexceptiontask1\TXT\27.txt",
             @"C:\c#labs\labaexceptiontask1\labaexceptiontask1\TXT\28.txt",
             @"C:\c#labs\labaexceptiontask1\labaexceptiontask1\TXT\29.txt"
            };
            List<string> nofiles = new List<string>();
            List<string> badData = new List<string>();
            List<string> overflowData = new List<string>();
            DoFiles file = new DoFiles(files, nofiles, badData, overflowData);
            file.ReadFiles();
            file.CreateFiles();
            double average = file.Average();
            Console.WriteLine($"Average of  products: {average}");
        }
    }
}