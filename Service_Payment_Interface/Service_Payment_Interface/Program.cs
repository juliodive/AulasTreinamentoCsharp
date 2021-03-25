using System;
using System.Globalization;
using entities;
using services;

namespace Service_Payment_Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter contract data: ");
            Console.Write("Number: ");
            int numberContract = int.Parse(Console.ReadLine());
            Console.Write("Date (dd/MM/yyyy): ");
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.Write("Contract Value: ");
            double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter number os installments: ");
            int installments = int.Parse(Console.ReadLine());

            Contract contract = new Contract(numberContract, date, value);
            ContractService contractService = new ContractService(new PaypalService());
            contractService.ProcessContract(contract, installments);

            Console.WriteLine("Installments: ");
            foreach (Installment cont in contract.Installments)
            {
                Console.WriteLine(cont);
            }
        }
    }
}
