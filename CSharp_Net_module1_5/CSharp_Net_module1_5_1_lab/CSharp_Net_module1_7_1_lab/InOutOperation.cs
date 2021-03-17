using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Threading;

namespace CSharp_Net_module1_7_1_lab
{
    class InOutOperation
    {
        // 1) declare properties  CurrentPath - path to file (without name of file), CurrentDirectory - name of current directory,
        // CurrentFile - name of current file

        private DirectoryInfo currentPath;
        public DirectoryInfo CurrentPath
        {
            get { return currentPath; }
            set { currentPath = value; }
        }

        public string CurrentFile { get; set; }

        public string CurrentDirectory { get; set; }

        public InOutOperation()
        {
            currentPath = new DirectoryInfo(".");
            CurrentFile = "dat.txt";
            CurrentDirectory = currentPath.Name;
        }
        // 2) declare public methods:
        //ChangeLocation() - change of CurrentPath; 
        // method takes new file path as parameter, creates new directories (if it is necessary)

        public void ChangeLocation(string location)
        {
            this.currentPath = new DirectoryInfo(location);
        }

        // CreateDirectory() - create new directory in current location
        public void CreateDirectory(string name)
        {
            Directory.CreateDirectory(currentPath.FullName + @"\" + name.Replace(" ", ""));
        }
        // WriteData() – save data to file
        // method takes data (info about computers) as parameter
        public void WriteData(Computer[] data)
        {
            using (StreamWriter sw = File.CreateText(CurrentFile))
            {
                foreach (Computer item in data)
                {
                    sw.WriteLine("================================");
                    sw.WriteLine($"Cores:      {item.Cores}");
                    sw.WriteLine($"Frequencys: {item.Frequency}");
                    sw.WriteLine($"Memory:     {item.Memory}");
                    sw.WriteLine($"Hdd:        {item.Hdd}");
                }
                sw.WriteLine("================================");
            }
        }
        // ReadData() – read data from file
        // method returns info about computers after reading it from file
        public void ReadData()
        {
            using (StreamReader sr = File.OpenText(CurrentFile))
            {
                string input = null;
                while ((input = sr.ReadLine()) != null)
                {
                    Console.WriteLine(input);
                }
            }
        }
        // WriteZip() – save data to zip file
        // method takes data (info about computers) as parameter

        // ReadZip() – read data from file
        // method returns info about computers after reading it from file

        // ReadAsync() – read data from file asynchronously
        // method is async
        // method returns Task with info about computers
        // use ReadLineAsync() method to read data from file
        // Note: don't forget about await

        // 7)
        // ADVANCED:
        // WriteToMemoryStream() – save data to memory stream
        // method takes data (info about computers) as parameter
        // info about computers is saved to Memory Stream

        // use  method GetBytes() from class UnicodeEncoding to save array of bytes from string data 
        // create new file stream
        // use method WriteTo() to save memory stream to file stream 
        // method returns file stream

        // WriteToFileFromMemoryStream() – save data to file from memory stream and read it
        // method takes file stream as parameter
        // save data to file      


        // Note: 
        // - use '//' in path string or @ before it (for correct path handling without escape sequence)
        // - use 'using' keyword to organize correct working with files
        // - don't forget to check path before any file or directory operations
        // - don't forget to check existed directory and file before creating
        // use File class to check files, Directory class to check directories, Path to check path


    }
}
