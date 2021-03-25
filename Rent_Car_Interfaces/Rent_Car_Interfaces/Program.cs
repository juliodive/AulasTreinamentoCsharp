using System;
using services;
using entities;
using System.Globalization;

namespace Rent_Car_Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Rent data: ");
            Console.Write("Car model: ");
            string model = Console.ReadLine();
            Console.Write("Pickup (dd/MM/yyyy hh:mm): ");
            DateTime start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            Console.Write("Return (dd/MM/yyyy hh:mm): ");
            DateTime finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                                  
            Console.Write("Enter price per hour: ");
            double priceHour = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
            Console.Write("Enter price per day: ");
            double priceDay = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
            
            CarRent carRent = new CarRent(start, finish, new Vehicle(model));
            RentalService rentalService = new RentalService(priceHour, priceDay,new BrazilTaxService());

            rentalService.ProcessInvoice(carRent);

            Console.WriteLine("INVOICE: ");
            Console.WriteLine(carRent.Invoice);
        }
    }
}
