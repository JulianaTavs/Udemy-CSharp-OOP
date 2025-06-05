namespace Ex17
{
    public class HourContract
    {
        public DateTime Date { get; set; }
        public double ValuePerHour { get; set; }
        public int Hours { get; set; }

        private ValidatingData validatingData = new ValidatingData();
        public HourContract()
        {
            Date = validatingData.GetAValidDateTime();
            ValuePerHour = validatingData.GetAValidValuePerHour();
            Hours = validatingData.GetValidHours();
        }
        public double TotalValue()
        {
            return ValuePerHour * Hours;
        }
    }
}