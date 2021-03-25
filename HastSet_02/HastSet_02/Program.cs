using System;
using System.Collections.Generic;

namespace HastSet_02
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> a = new HashSet<int>();
            HashSet<int> b = new HashSet<int>();
            HashSet<int> c = new HashSet<int>();

            Console.Write("How many students for course A? ");
            int nA = int.Parse(Console.ReadLine());
            for(int i = 0; i<nA; i++)
            {
                int value = int.Parse(Console.ReadLine());
                a.Add(value);
            }

            Console.Write("How many students for course B? ");
            int nB = int.Parse(Console.ReadLine());
            for (int i = 0; i < nB; i++)
            {
                int value = int.Parse(Console.ReadLine());
                b.Add(value);
            }

            Console.Write("How many students for course A? ");
            int nC = int.Parse(Console.ReadLine());
            for (int i = 0; i < nC; i++)
            {
                int value = int.Parse(Console.ReadLine());
                c.Add(value);
            }

            HashSet<int> all = new HashSet<int>(a);
            all.UnionWith(b);
            all.UnionWith(c);
            Console.Write("Total students: " + all.Count);

        }
    }
}
