using System;

namespace Problema_Motivador_01
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintService<int> printService = new PrintService<int>();

            Console.Write("How many values? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int value = int.Parse(Console.ReadLine());
                printService.AddValue(value);
            }
            printService.Print();
            Console.WriteLine("Fist: " + printService.Fist());
        }
    }
}
