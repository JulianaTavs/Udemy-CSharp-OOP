
using System.Globalization;

namespace Ex28
{
    class CarRental
    {
        public string Model { get; set; }
        public DateTime PickUp { get; set; }
        public DateTime Devolucao { get; set; }
        public decimal HourlyPrice { get; set; }
        public decimal DailyPrice { get; set; }
        public TimeSpan Duration
        {
            get { return Devolucao.Subtract(PickUp); }
        }
        public CarRental(string model, DateTime pickup, DateTime devolucao, decimal hourlyPrice,
        decimal dailyPrice)
        {
            Model = model;
            PickUp = pickup;
            Devolucao = devolucao;
            HourlyPrice = hourlyPrice;
            DailyPrice = dailyPrice;
        }

        public decimal BasicPrice()
        {
            if (Duration.Days == 0)
            {
                if (Duration.Hours <= 12)
                {
                    if (Duration.Minutes > 0)
                    {
                        return (decimal)Math.Ceiling(Duration.TotalHours) * HourlyPrice;
                    }
                return Duration.Hours * HourlyPrice;
                }
            }
            else if (Duration.Hours > 0)
            {
                return (decimal)Math.Ceiling(Duration.TotalDays) * DailyPrice;
            }
            return Duration.Days * DailyPrice;
        }
        public decimal Tax()
        {
            decimal basicPayment = BasicPrice();
            if (basicPayment <= 100)
            {
                return basicPayment * 0.2m;
            }
            return basicPayment * 0.15m;
        }
        public decimal TotalPrice()
        {
            return BasicPrice() + Tax();
        }
        public override string ToString()
        {
            return
                   "--------------------------------------" + "\n" +
                   "INVOICE: " + "\n" +
                   "Basic Payment: " + BasicPrice().ToString("F2", CultureInfo.InvariantCulture) + "\n" +
                   "Tax: " + Tax().ToString("F2", CultureInfo.InvariantCulture) + "\n" +
                   "Total Payment: " + TotalPrice().ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}