using Ex25;

List<Reservation> reservations = new List<Reservation>();
GettingValidData data = new GettingValidData();

int numberofReservations = data.GetAValidInt("How many reservations are you making: ",
"Invalid input. Please enter a valid integer number of reservations: ");

for (int i = 1; i <= numberofReservations; i++)
{
    int roomNumber = data.GetAValidInt($"Room number {i}: ",
    "Invalid input. Please enter a valid integer room number: ");

    DateTime checkInParsedDate = data.GetAValidCheckInDate();
    DateTime checkOutParsedDate = data.GetAValidCheckOutDate(checkInParsedDate);

    reservations.Add(new Reservation(roomNumber, checkInParsedDate, checkOutParsedDate));
}

for (int i = 1; i <= numberofReservations; i++)
{
    Console.WriteLine($"{i} - {reservations[i - 1]} ");
}

Console.Write("Would you like to update any reservation? ");
Console.WriteLine("Enter y for yes or n for no: ");
char userChoice = data.GetAValidChar();
int j = 0;

switch (userChoice)
{
    case 'y':

        j = data.GetAValidInt("Which reservation would you like to update? ",
        "Invalid input. Please enter a valid integer for the number of the " +
        "reservation: ");

        break;

    case 'n':
        Console.WriteLine("Okay. We are closing the application.");
        Environment.Exit(0);
        break;
}


while (true)
{
    if (j >= 1 && j <= reservations.Count)
    {

        DateTime updatedCheckIn = data.GetAValidCheckInDate();

        DateTime updatedCheckOut = data.GetAValidCheckOutDate(updatedCheckIn);

        try
        {
            reservations[j - 1].UpdateDates(updatedCheckIn, updatedCheckOut);
            // Se chegou aqui, a atualização foi bem-sucedida, podemos sair do loop
            Console.WriteLine("Reserva atualizada com sucesso!");
            break;
        }
        catch (ReservationException ex) // Captura a exceção específica lançada por Reservation
        {
            Console.WriteLine($"Falha ao atualizar a reserva: {ex.Message}");
            // Não damos 'break' aqui, o loop continua e o usuário é repromptado pelas novas datas
        }
    }
    else
    {
        Console.WriteLine($"Choose the number of the reservation between 1 and {reservations.Count}: ");
    }

}

for (int i = 1; i <= numberofReservations; i++)
{
    Console.WriteLine($"{i} - {reservations[i - 1]} ");
}








