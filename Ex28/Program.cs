using Ex28;

ValidatingData validatingData = new ValidatingData();

Console.WriteLine("Enter rental data: ");

string carModel = validatingData.GetAValidString("Car model: ",
"Invalid data. Please enter a valid car model name: ");
DateTime pickUp = validatingData.GetAValidDateTime("Pickup(dd/MM/yyyy hh:mm): ",
"Invalid data. Please enter a valid pickup date (dd/MM/yyyy hh:mm):");
DateTime devolucao = validatingData.GetAValidDateTime("Return(dd/MM/yyyy hh:mm): ",
"Invalid data. Please enter a valid return date (dd/MM/yyyy hh:mm):");
decimal hourlyPrice = validatingData.GetAValidDecimal("Enter price per hour: ",
"Invalid data. Please enter a valid price per hour: ");
decimal dailyPrice = validatingData.GetAValidDecimal("Enter price per day: ",
"Invalid data. Please enter a valid price per day: ");

CarRental carRental = new CarRental(carModel, pickUp, devolucao, hourlyPrice, dailyPrice);
Console.WriteLine(carRental);

Console.WriteLine("Press any key to end the application...");
Console.ReadKey();
