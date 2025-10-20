using Ex35;

Instrutor Alex = new Instrutor();
Instrutor Marcio = new Instrutor();
Instrutor Marília = new Instrutor();
Instrutor Juliana = new Instrutor();
Instrutor Lucia = new Instrutor();
Instrutor Luciano = new Instrutor();


Console.WriteLine("Que tipo de usuário você é: ");
Console.WriteLine("1 - Instrutor");
Console.WriteLine("2 - Aluno");
Console.WriteLine("3 - Sair");

Console.Write("Opção selecionada: ");
int opcao1 = int.Parse(Console.ReadLine());

switch (opcao1)
{
    case 1:

        Console.WriteLine("\nDigite o nome de um instrutor para selecionar: ");

        foreach (string nomeEnum in Enum.GetNames(typeof(NomesDosInstrutores)))
        {
            Console.WriteLine($"- {nomeEnum}");
        }

        Console.Write("Opção selecionada: ");
        NomesDosInstrutores instrutorEscolhido;

        while (true)
        {
            string? nomeDigitado = Console.ReadLine();

            // Tenta converter a string digitada para um membro do enum
            if (Enum.TryParse(nomeDigitado, true, out instrutorEscolhido))
            {
                // Se a conversão for bem-sucedida, saímos do loop
                break;
            }
            else
            {
                Console.WriteLine("Nome de instrutor inválido. Por favor, tente novamente.");
            }
        }

        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine($"\nOlá {instrutorEscolhido} - O que você gostaria de fazer?");
            Console.WriteLine("1 - Adicionar curso");
            Console.WriteLine("2 - Ver total de alunos dos seus cursos");
            Console.WriteLine("3 - Ver seus cursos cadastrados");
            Console.WriteLine("4 - Excluir curso");
            Console.WriteLine("5 - Sair");

            Console.Write("Opção selecionada: ");
            int opcao2 = int.Parse(Console.ReadLine());

            bool repetirAcao = true;
            switch (opcao2)
            {
                case 1:
                    while (repetirAcao)
                    {
                        switch (instrutorEscolhido)
                        {
                            case NomesDosInstrutores.Alex:
                                Alex.AdicionarCurso();
                                break;
                            case NomesDosInstrutores.Marcio:
                                Marcio.AdicionarCurso();
                                break;
                            case NomesDosInstrutores.Marília:
                                Marília.AdicionarCurso();
                                break;
                            case NomesDosInstrutores.Juliana:
                                Juliana.AdicionarCurso();
                                break;
                            case NomesDosInstrutores.Lucia:
                                Lucia.AdicionarCurso();
                                break;
                            case NomesDosInstrutores.Luciano:
                                Luciano.AdicionarCurso();
                                break;
                        }
                        Console.WriteLine("Deseja adicionar mais cursos?");
                        Console.WriteLine("1 - Sim");
                        Console.WriteLine("2 - Não");
                        Console.Write("Opção selecionada: ");
                        int prosseguir = int.Parse(Console.ReadLine());
                        if (prosseguir == 2)
                        {
                            repetirAcao = false;
                        }
                    }
                    break;
                case 2:

                    break;
                case 3:
                    switch (instrutorEscolhido)
                    {
                        case NomesDosInstrutores.Alex:
                            Console.WriteLine("Curso(s): ");
                            Alex.ImprimirCursos();
                            break;
                        case NomesDosInstrutores.Marcio:
                            Console.WriteLine("Curso(s): ");
                            Marcio.ImprimirCursos();
                            break;
                        case NomesDosInstrutores.Marília:
                            Console.WriteLine("Curso(s): ");
                            Marília.ImprimirCursos();
                            break;
                        case NomesDosInstrutores.Juliana:
                            Console.WriteLine("Curso(s): ");
                            Juliana.ImprimirCursos();
                            break;
                        case NomesDosInstrutores.Lucia:
                            Console.WriteLine("Curso(s): ");
                            Lucia.ImprimirCursos();
                            break;
                        case NomesDosInstrutores.Luciano:
                            Console.WriteLine("Curso(s): ");
                            Luciano.ImprimirCursos();
                            break;
                    }
                    break;
                case 4:
                    break;
                case 5:
                    break;
            }

            Console.WriteLine("Gostaria de fazer mais alguma operação?");
            Console.WriteLine("1 - Sim");
            Console.WriteLine("2 - Não");
            Console.Write("Opção selecionada: ");
            int escolha = int.Parse(Console.ReadLine());
            switch (escolha)
            {
                case 1:
                    break;
                case 2:
                    continuar = false;
                    Console.WriteLine("Obrigado por acessar o portal! Até mais!");
                    Console.ReadKey();
                    break;
            }
        }
        break;

    case 2:
        Console.WriteLine("Olá aluno - O que você gostaria de fazer?");
        Console.WriteLine("1 - Se matricular em curso");
        Console.WriteLine("2 - Cancelar matrícula");
        Console.WriteLine("3 - Ver seus cursos matriculados");
        Console.WriteLine("4 - Sair");

        Console.Write("Opção selecionada: ");

        int opcao3 = int.Parse(Console.ReadLine());

        switch (opcao3)
        {

        }
        break;
}


