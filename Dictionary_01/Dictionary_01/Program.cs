using System;
using System.IO;
using System.Collections.Generic;

namespace Dictionary_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            Console.WriteLine("Enter file full path: ");
            string path = Console.ReadLine();
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(',');
                        string canditate = line[0];
                        int votes = int.Parse(line[1]);

                        if (dictionary.ContainsKey(canditate))
                        {
                            dictionary[canditate] += votes;
                        }
                        else
                        {
                            dictionary[canditate] = votes;
                        }
                    }
                    foreach(var item in dictionary)
                    {
                        Console.WriteLine(item.Key + " : " + item.Value);
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
