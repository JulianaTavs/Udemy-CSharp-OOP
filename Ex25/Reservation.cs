using System.Text;

namespace Ex25
{
    class Reservation
    {
        public int RoomNumber { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public Reservation(int roomNumber, DateTime checkin, DateTime checkout)
        {
            RoomNumber = roomNumber;
            CheckIn = checkin;
            CheckOut = checkout;
        }
        int Duration()
        {
            TimeSpan duration = CheckOut.Subtract(CheckIn);
            return duration.Days;
        }
        public void UpdateDates(DateTime checkin, DateTime checkout)
        {
            CheckIn = checkin;
            CheckOut = checkout;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("Reservation: ");
            sb.Append($" Room {RoomNumber},");
            sb.Append($" Check-in: {CheckIn.ToShortDateString()},");
            sb.Append($" Check-out: {CheckOut.ToShortDateString()},");
            sb.Append($" {Duration()} night(s)");
            return sb.ToString();
        }
    }
}