using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using entities;

namespace Reader_Sort_List_IComparable
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string path = @"c:\temp\text.csv";

                using(StreamReader sr = File.OpenText(path))
                {
                    List<Employeer> employeers = new List<Employeer>();
                    while (!sr.EndOfStream)
                    {
                        employeers.Add(new Employeer(sr.ReadLine()));
                    }
                    employeers.Sort();
                    foreach(Employeer list in employeers)
                    {
                        Console.WriteLine(list);
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
