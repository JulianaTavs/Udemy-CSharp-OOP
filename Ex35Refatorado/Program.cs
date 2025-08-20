using Ex35Refatorado;

GerenciadorDeArquivos.CarregarDados(out var instrutores, out var todosCursos);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Que tipo de usuário você é: ");
                Console.WriteLine("1 - Instrutor");
                Console.WriteLine("2 - Aluno");
                Console.WriteLine("3 - Sair");
                Console.Write("Opção selecionada: ");
                
                if (!int.TryParse(Console.ReadLine(), out int opcao1))
                {
                    Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }

                switch (opcao1)
                {
                    case 1:
                        LogicaInstrutor(instrutores, todosCursos);
                        break;
                    case 2:
                        LogicaAluno(instrutores, todosCursos);
                        break;
                    case 3:
                        Console.WriteLine("Obrigado por acessar o portal! Até mais!");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        

        static void LogicaInstrutor(
            Dictionary<NomesDosInstrutores, Instrutor> instrutores,
            Dictionary<string, Curso> todosCursos)
        {
            Console.Clear();
            Console.WriteLine("Digite o nome de um instrutor para selecionar: ");

            foreach (string nomeEnum in Enum.GetNames(typeof(NomesDosInstrutores)))
            {
                Console.WriteLine($"- {nomeEnum}");
            }

            Console.Write("Opção selecionada: ");
            NomesDosInstrutores instrutorEscolhido;

            while (!Enum.TryParse(Console.ReadLine(), true, out instrutorEscolhido))
            {
                Console.WriteLine("Nome de instrutor inválido. Por favor, tente novamente.");
                Console.Write("Opção selecionada: ");
            }
            
            Instrutor instrutorAtual = instrutores[instrutorEscolhido];
            
            bool continuar = true;
            while (continuar)
            {
                Console.Clear();
                Console.WriteLine($"\nOlá {instrutorAtual.NomeInstrutor} - O que você gostaria de fazer?");
                Console.WriteLine("1 - Adicionar curso");
                Console.WriteLine("2 - Ver total de alunos dos seus cursos");
                Console.WriteLine("3 - Ver seus cursos cadastrados");
                Console.WriteLine("4 - Excluir curso");
                Console.WriteLine("5 - Voltar ao menu principal");

                Console.Write("Opção selecionada: ");
                if (!int.TryParse(Console.ReadLine(), out int opcao2))
                {
                    Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }

                switch (opcao2)
                {
                    case 1:
                        Console.Write("Qual curso você gostaria de adicionar? ");
                        string nomeCursoAdd = Console.ReadLine();
                        var novoCurso = new Curso(nomeCursoAdd);
                        if (!todosCursos.ContainsKey(nomeCursoAdd))
                        {
                            todosCursos[nomeCursoAdd] = novoCurso;
                        }
                        instrutorAtual.CursosMinistrados.Add(todosCursos[nomeCursoAdd]);
                        Console.WriteLine($"Curso '{nomeCursoAdd}' adicionado para o instrutor {instrutorAtual.NomeInstrutor}!");
                        break;

                    case 2:
                        int totalAlunos = instrutorAtual.TotalDeAlunosDosMeusCursos();
                        Console.WriteLine($"Total de alunos únicos em seus cursos: {totalAlunos}");
                        break;

                    case 3:
                        Console.WriteLine("Curso(s) ministrados:");
                        if (instrutorAtual.CursosMinistrados.Any())
                        {
                            foreach (var curso in instrutorAtual.CursosMinistrados)
                            {
                                Console.WriteLine($"- {curso.NomeDoCurso} ({curso.AlunosMatriculados.Count} aluno(s))");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nenhum curso cadastrado.");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Qual curso você gostaria de excluir?");
                        string nomeCursoRemover = Console.ReadLine();
                        var cursoParaRemover = new Curso(nomeCursoRemover);
                        if (instrutorAtual.CursosMinistrados.Remove(cursoParaRemover))
                        {
                            Console.WriteLine($"Curso '{nomeCursoRemover}' removido com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine($"Curso '{nomeCursoRemover}' não encontrado.");
                        }
                        break;

                    case 5:
                        GerenciadorDeArquivos.SalvarDados(instrutores);
                        continuar = false;
                        break;
                    
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
        
         static void LogicaAluno(
            Dictionary<NomesDosInstrutores, Instrutor> instrutores,
            Dictionary<string, Curso> todosCursos)
        {
            Console.Clear();
            Console.Write("Digite seu nome para entrar: ");
            string nomeAluno = Console.ReadLine();
            
            // Lógica para encontrar ou criar o aluno
            var todosAlunos = new HashSet<Aluno>();
            foreach(var instrutor in instrutores.Values)
            {
                foreach(var curso in instrutor.CursosMinistrados)
                {
                    todosAlunos.UnionWith(curso.AlunosMatriculados);
                }
            }

            Aluno? alunoAtual = todosAlunos.FirstOrDefault(a => a.Nome.Equals(nomeAluno, StringComparison.OrdinalIgnoreCase));
            if(alunoAtual == null)
            {
                alunoAtual = new Aluno(nomeAluno);
                Console.WriteLine($"Bem-vindo(a), {alunoAtual.Nome}! Seu ID é {alunoAtual.ID}.");
            }
            else
            {
                Console.WriteLine($"Bem-vindo(a) de volta, {alunoAtual.Nome}! Seu ID é {alunoAtual.ID}.");
            }
            
            bool continuar = true;
            while(continuar)
            {
                Console.Clear();
                Console.WriteLine($"\nOlá, {alunoAtual.Nome}! O que você gostaria de fazer?");
                Console.WriteLine("1 - Se matricular em um curso");
                Console.WriteLine("2 - Cancelar matrícula em um curso");
                Console.WriteLine("3 - Ver seus cursos matriculados");
                Console.WriteLine("4 - Voltar ao menu principal");

                Console.Write("Opção selecionada: ");
                if (!int.TryParse(Console.ReadLine(), out int opcao3))
                {
                    Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }

                switch (opcao3)
                {
                    case 1:
                        Console.WriteLine("Cursos disponíveis:");
                        if (todosCursos.Any())
                        {
                            foreach (var curso in todosCursos.Keys)
                            {
                                Console.WriteLine($"- {curso}");
                            }
                            Console.Write("Digite o nome do curso para se matricular: ");
                            string nomeCursoMatricula = Console.ReadLine();
                            if (todosCursos.ContainsKey(nomeCursoMatricula))
                            {
                                var curso = todosCursos[nomeCursoMatricula];
                                if(alunoAtual.CursosMatriculados.Add(curso))
                                {
                                    curso.AlunosMatriculados.Add(alunoAtual);
                                    Console.WriteLine($"Matrícula em '{nomeCursoMatricula}' realizada com sucesso!");
                                }
                                else
                                {
                                    Console.WriteLine("Você já está matriculado(a) neste curso.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Curso não encontrado.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nenhum curso disponível.");
                        }
                        break;

                    case 2:
                        Console.WriteLine("Seus cursos matriculados:");
                        if (alunoAtual.CursosMatriculados.Any())
                        {
                            foreach (var curso in alunoAtual.CursosMatriculados)
                            {
                                Console.WriteLine($"- {curso.NomeDoCurso}");
                            }
                            Console.Write("Digite o nome do curso para cancelar a matrícula: ");
                            string nomeCursoCancelar = Console.ReadLine();
                            if(todosCursos.ContainsKey(nomeCursoCancelar))
                            {
                                var curso = todosCursos[nomeCursoCancelar];
                                if(alunoAtual.CursosMatriculados.Remove(curso))
                                {
                                    curso.AlunosMatriculados.Remove(alunoAtual);
                                    Console.WriteLine($"Matrícula em '{nomeCursoCancelar}' cancelada com sucesso!");
                                }
                                else
                                {
                                    Console.WriteLine("Você não está matriculado(a) neste curso.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Curso não encontrado.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Você não está matriculado(a) em nenhum curso.");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Cursos em que você está matriculado(a):");
                        if (alunoAtual.CursosMatriculados.Any())
                        {
                            foreach (var curso in alunoAtual.CursosMatriculados)
                            {
                                Console.WriteLine($"- {curso.NomeDoCurso}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Você não está matriculado(a) em nenhum curso.");
                        }
                        break;

                    case 4:
                        GerenciadorDeArquivos.SalvarDados(instrutores);
                        continuar = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
    

