using entities;
using System;

namespace services
{
    class RentalService
    {
        public double PricePerHour { get; set; }
        public double PricePerDay { get; set; }

        private ITaxService _taxService;

        public RentalService(double pricePerHour, double pricePerDay, ITaxService taxService)
        {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
            _taxService = taxService;
        }

        public void ProcessInvoice(CarRent carRent)
        {
            TimeSpan duration = carRent.Finish.Subtract(carRent.Start);

            double basicPayment = 0.0;

            if (duration.TotalHours <= 12.00)
            {
                basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours);
            }
            else
            {
                basicPayment = PricePerDay * Math.Ceiling(duration.TotalDays);
            }

            double tax = _taxService.Tax(basicPayment);

            carRent.Invoice = new Invoice(basicPayment, tax);
        }
    }
}
