using Ex36;

Candidato AlexBlue = new Candidato("Alex Blue");
Candidato MariaGreen = new Candidato("Maria Green");
Candidato BobBrown = new Candidato("Bob Brown");
Dictionary<string, int> resultadosVotacao = new Dictionary<string, int>
{
    { "Alex Blue", 0 },
    { "Maria Green", 0 },
    { "Bob Brown", 0 }
};

int qtdeCandidatos = resultadosVotacao.Count;

Console.Write("Quantas urnas existem? ");
int qtdeUrnas = int.Parse(Console.ReadLine());

Console.WriteLine("---------------------------------");
for (int i = 0; i < qtdeUrnas; i++)
{
    Console.WriteLine($"{i + 1}ª urna: ");

    for (int j = 0; j < qtdeCandidatos; j++)
    {
        Console.Write($"Digite o nome do {j + 1}º candidato (Alex Blue, Maria Green, Bob Brown): ");
        string nomeCompleto = Console.ReadLine();

        if (resultadosVotacao.ContainsKey(nomeCompleto))
        {
            Console.Write($"Digite quantos votos o(a) candidato(a) {nomeCompleto} teve: ");
            int numDeVotos;
            int.TryParse(Console.ReadLine(), out numDeVotos);

            GerenciadorDeArquivos.GravarDados(nomeCompleto, numDeVotos);

            if (nomeCompleto.Equals("Alex Blue"))
            {
                AlexBlue.TotalVotos += numDeVotos;
                resultadosVotacao["Alex Blue"] = AlexBlue.TotalVotos;
            }
            else if (nomeCompleto.Equals("Maria Green"))
            {
                MariaGreen.TotalVotos += numDeVotos;
                resultadosVotacao["Maria Green"] = MariaGreen.TotalVotos;
            }
            else if (nomeCompleto.Equals("Bob Brown"))
            {
                BobBrown.TotalVotos += numDeVotos;
                resultadosVotacao["Bob Brown"] = BobBrown.TotalVotos;
            }
        }
        else
        {
            Console.WriteLine("Candidato não encontrado. Voto descartado.");
        }
    }
}

Console.WriteLine("---------------------------------");

Console.WriteLine("Resultados Finais:");
foreach (var item in resultadosVotacao)
{
    Console.WriteLine($"{item.Key}: {item.Value} votos");
}



