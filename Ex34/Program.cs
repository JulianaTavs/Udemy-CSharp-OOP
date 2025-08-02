using Ex34;

Console.WriteLine("Simulando logins de usuários...");


LogManager.RegistrarLogUsuario("Ana");
LogManager.RegistrarLogUsuario("Bruno");
LogManager.RegistrarLogUsuario("Carla");
LogManager.RegistrarLogUsuario("Juliana");
LogManager.RegistrarLogUsuario("Jacqueline");

Console.WriteLine("\nVerifique o arquivo 'log_usuarios.txt' para ver os registros.");

LogManager.TotalDistinctUsers();


Console.ReadKey(); 


