using Ex13;
// Criando uma instância do serviço de validação:
FuncionarioService funcionarioService = new FuncionarioService();

// Criando a lista para criar objetos Funcionario:
List<Funcionario> lista = new List<Funcionario>();

int i = 1;
while (true)
{
    Console.WriteLine($"Entre com as informações do funcionário {i}:");

    // Receber e validar os dados do usuário:
    int id = funcionarioService.ObterId();
    decimal salario = funcionarioService.ObterSalario();
    string nome = funcionarioService.ObterNome();

    // Criando o objeto Funcionario com os dados validados
    Funcionario funcionario = new Funcionario(id, salario, nome);

    lista.Add(funcionario);

    Console.WriteLine("Deseja continuar adicionando funcionários?");
    Console.WriteLine("Digite 1 para Continuar ou 2 para Encerrar: ");
    int continuar = int.Parse(Console.ReadLine());

    if (continuar == 1 || continuar == 2)
    {
        if (continuar == 1)
        {
            i++;
        }
        else
        {
            Console.WriteLine("Programa encerrado!");
            break;
        }
    }
    else
    {
        Console.WriteLine("Opção inválida. Digite 1 para Continuar ou 2 para Encerrar: ");
    }
}

Console.WriteLine("Entre o ID do funcionário que receberá o aumento de salário: ");
//Continuar daqui
int idFuncionario = int.Parse(Console.ReadLine()); // Você pode pegar isso do usuário ou de outro lugar
Funcionario funcionarioSelecionado = lista.FirstOrDefault(f => f.Id == idFuncionario);

Console.WriteLine("Entre a porcentagem de aumento: ");
double percentualAumento = double.Parse(Console.ReadLine());

// Verificar se o funcionário foi encontrado
if (funcionarioSelecionado != null)
{
    // Aumentar o salário de acordo com o que foi entrado pelo usuário:
    Funcionario.IncreaseSalary(funcionarioSelecionado, percentualAumento);
    Console.WriteLine($"\nSalário atualizado do funcionário {funcionarioSelecionado.Nome}: {funcionarioSelecionado.Salario}");
}
else
{
    Console.WriteLine("Funcionário não encontrado.");
}

i = 1;
foreach (var item in lista)
{
    Console.WriteLine($"\nFuncionário #{i}: ");
    Console.WriteLine(item);
    i++;
}

