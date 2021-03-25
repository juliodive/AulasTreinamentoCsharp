using System;
using Entities;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;

namespace Linq_02
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            try
            {
                Console.Write("Enter full file path: ");
                string path = Console.ReadLine();

                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] lines = sr.ReadLine().Split(',');
                        string name = lines[0];
                        double price = double.Parse(lines[1], CultureInfo.InvariantCulture);
                        products.Add(new Product(name, price));
                    }
                }
                var avg = products.Select(p => p.Price).DefaultIfEmpty(0.0).Average();
                Console.WriteLine("Average price: " + avg.ToString("F2",CultureInfo.InvariantCulture));

                var prod = products.Where(p => p.Price < avg).OrderByDescending(p => p.Name).Select(p => p.Name);
                foreach(string name in prod)
                {
                    Console.WriteLine(name);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
