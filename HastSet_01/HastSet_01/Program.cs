using System;
using System.IO;
using Entities;
using System.Collections.Generic;

namespace HastSet_01
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<LogAcess> logAcesses = new HashSet<LogAcess>();

            Console.Write("Enter file full path: ");
            string sourcePath = Console.ReadLine();
            try
            {
                using (StreamReader sr = File.OpenText(sourcePath))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(' ');
                        string name = line[0];
                        DateTime instant = DateTime.Parse(line[1]);
                        logAcesses.Add(new LogAcess { Instant = instant, Name = name });
                    }
                    Console.WriteLine("Total users: " + logAcesses.Count);

                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
