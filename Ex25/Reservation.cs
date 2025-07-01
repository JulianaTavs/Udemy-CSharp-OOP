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
            // Validação 1: Check-in não pode ser no passado
            if (checkin.Date < DateTime.Today.Date)
            {
                // Lança uma exceção controlada
                throw new ReservationException($" A data de check-in '{checkin.ToShortDateString()}' "
                + "deve ser hoje ou no futuro.");
            }
            // Validação 2: Check-out deve ser maior que check-in
            if (checkout.Date <= checkin.Date) // Usamos <= para garantir que checkout seja
            //  estritamente depois
            {
                // Lança uma exceção controlada
                throw new ReservationException($" A data de check-out '{checkout.ToShortDateString()}' "
                + $"deve ser maior que a data de check-in '{checkin.ToShortDateString()}'.");
            }
            // Se passou pelas validações, as datas são válidas e podem ser atribuídas
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