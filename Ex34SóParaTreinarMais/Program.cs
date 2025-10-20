using Ex34SóParaTreinarMais;

Usuario.GerenciadorDeLog("Juliana");
Usuario.GerenciadorDeLog("Carminha");
Usuario.GerenciadorDeLog("Jacqueline");

Usuario.GravadorDeLogsDistintos();

foreach (Usuario usuario in Usuario.usuarios)
{
    Console.WriteLine(usuario);
}
