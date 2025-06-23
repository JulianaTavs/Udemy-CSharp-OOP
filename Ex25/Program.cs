
using Ex25;

List<Reservation> reservations = new List<Reservation>();
GettingValidData data = new GettingValidData();

int numberofReservations = data.GetAValidInt("How many reservations are you making: ",
"Invalid input. Please enter a valid integer number of reservations: ");

for (int i = 1; i <= numberofReservations; i++)
{
    int roomNumber = data.GetAValidInt($"Room number {i}: ",
    "Invalid input. Please enter a valid integer room number: ");

    DateTime CheckInParsedDate = data.GetAValidCheckInDate();
    DateTime CheckOutParsedDate = data.GetAValidCheckOutDate();

    reservations.Add(new Reservation(roomNumber, CheckInParsedDate, CheckOutParsedDate));
}

for (int i = 1; i <= numberofReservations; i++)
{
    Console.WriteLine($"{i} - {reservations[i - 1]} ");
}

Console.Write("Would you like to update any reservation? ");
int j = data.GetAValidNumberOfTheReservation();
DateTime updatedCheckIn = data.GetAValidCheckInDate();
DateTime updatedCheckOut = data.GetAValidCheckOutDate();

reservations[j - 1].UpdateDates(updatedCheckIn, updatedCheckOut);

for (int i = 1; i <= numberofReservations; i++)
{
    Console.WriteLine($"{i} - {reservations[i - 1]} ");
}








