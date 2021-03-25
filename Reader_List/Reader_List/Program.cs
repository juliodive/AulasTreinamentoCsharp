using System;
using System.IO;
using System.Collections.Generic;

namespace Reader_List
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string souceFilePath = @"c:\temp\text.csv";

                using (StreamReader sr = File.OpenText(souceFilePath))
                {
                    List<string> list = new List<string>();
                    while (!sr.EndOfStream)
                    {
                        list.Add(sr.ReadLine());
                    }
                    list.Sort();
                    foreach(string line in list)
                    {
                        Console.WriteLine(line);
                    }

                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
