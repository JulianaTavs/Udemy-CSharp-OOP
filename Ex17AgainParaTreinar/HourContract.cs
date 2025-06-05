namespace Ex17AgainParaTreinar
{
    public class HourContract
    {
        public DateTime Date { get; set; } = new DateTime();
        public double ValuePerHour { get; set; }
        public int Hours { get; set; }
        public HourContract()
        {

        }
        public HourContract(DateTime date, double valuePerHour, int hours)
        {
            Date = date;
            ValuePerHour = valuePerHour;
            Hours = hours;
        }
        public double TotalValue()
        {
            return ValuePerHour * Hours;
        }
    }
}