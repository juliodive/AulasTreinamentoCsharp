using System.Globalization;
using System;
using entities;
using System.IO;

namespace File_Summary
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Products prod = new Products();
                while (!prod.Tentativa)

                    try
                    {
                        Console.Write("Enter the path: ");
                        string sourceFilePath = Console.ReadLine();

                        string[] lines = File.ReadAllLines(sourceFilePath);

                        string sourceFolderPath = Path.GetDirectoryName(sourceFilePath);
                        string targetFolderPath = sourceFolderPath + @"\out";
                        string targetFilePath = targetFolderPath + @"\summary.csv";

                        Directory.CreateDirectory(targetFolderPath);

                        using (StreamWriter sw = File.AppendText(targetFilePath))
                        {
                            foreach (string line in lines)
                            {
                                string[] fields = line.Split(',');
                                string name = fields[0];
                                double price = double.Parse(fields[1], CultureInfo.InvariantCulture);
                                int amount = int.Parse(fields[2]);

                                Products prod2 = new Products(name, price, amount);

                                sw.WriteLine(prod2.Name + "," + prod2.Total().ToString("F2", CultureInfo.InvariantCulture));
                            }
                        }
                        prod.Tentativa = true;
                        using (StreamReader sr = File.OpenText(targetFilePath))
                        {
                            while (!sr.EndOfStream)
                            {
                                string line = sr.ReadLine();
                                Console.WriteLine(line);
                            }
                        }
                        Console.ReadLine();
                    }
                    catch (IOException e)
                    {
                        Console.WriteLine("Erro caminho não encontrado!");
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Tente Novamente!: ");
                    }
            }
            catch (IOException e)
            {
                Console.WriteLine("Ocorreu um erro");
                Console.WriteLine(e.Message);
            }


        }
    }
}
