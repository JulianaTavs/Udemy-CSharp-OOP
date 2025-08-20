using System.Reflection;

namespace Ex35Refatorado
{
    public class GerenciadorDeArquivos
    {
        private const string CursosFile = "cursos.txt";
        private const string AlunosFile = "alunos.txt";
        
        // Salva os dados de todos os instrutores, alunos e cursos.
        public static void SalvarDados(Dictionary<NomesDosInstrutores, Instrutor> instrutores)
        {
            try
            {
                // Salva os cursos de cada instrutor
                using (StreamWriter swCursos = new StreamWriter(CursosFile, false))
                {
                    foreach (var instrutor in instrutores.Values)
                    {
                        string cursosString = string.Join(",", instrutor.CursosMinistrados.Select(c => c.NomeDoCurso));
                        swCursos.WriteLine($"{instrutor.NomeInstrutor}|{cursosString}");
                    }
                }
                
                // Salva os alunos e os cursos em que estão matriculados
                using (StreamWriter swAlunos = new StreamWriter(AlunosFile, false))
                {
                    // Usa um HashSet para garantir que cada aluno seja processado apenas uma vez
                    var todosAlunos = new HashSet<Aluno>();
                    foreach(var instrutor in instrutores.Values)
                    {
                        foreach(var curso in instrutor.CursosMinistrados)
                        {
                            todosAlunos.UnionWith(curso.AlunosMatriculados);
                        }
                    }
                    
                    foreach (var aluno in todosAlunos)
                    {
                        string cursosString = string.Join(",", aluno.CursosMatriculados.Select(c => c.NomeDoCurso));
                        swAlunos.WriteLine($"{aluno.ID}|{aluno.Nome}|{cursosString}");
                    }
                }
                Console.WriteLine("Dados salvos com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao salvar dados: {e.Message}");
            }
        }
        
        // Carrega todos os dados dos arquivos para as coleções em memória.
        public static void CarregarDados(
            out Dictionary<NomesDosInstrutores, Instrutor> instrutores,
            out Dictionary<string, Curso> todosCursos)
        {
            instrutores = Enum.GetValues(typeof(NomesDosInstrutores))
                .Cast<NomesDosInstrutores>()
                .ToDictionary(nome => nome, nome => new Instrutor(nome));

            todosCursos = new Dictionary<string, Curso>();
            var todosAlunos = new Dictionary<int, Aluno>();

            try
            {
                if (File.Exists(AlunosFile))
                {
                    foreach (string linha in File.ReadLines(AlunosFile))
                    {
                        string[] partes = linha.Split('|');
                        int id = int.Parse(partes[0]);
                        string nomeAluno = partes[1];
                        var aluno = new Aluno(nomeAluno);
                        
                        // Obter o valor do campo estático e fazer um cast para int
                        var proximoIdField = typeof(Aluno).GetField("_proximoID", BindingFlags.NonPublic | BindingFlags.Static);
                        if (proximoIdField != null)
                        {
                            int currentProximoId = (int)proximoIdField.GetValue(null)!;
                            
                            if (id >= currentProximoId)
                            {
                                proximoIdField.SetValue(null, id + 1);
                            }
                        }
                        
                        todosAlunos[aluno.ID] = aluno;
                        
                        if (partes.Length > 2 && !string.IsNullOrEmpty(partes[2]))
                        {
                            string[] nomesCursos = partes[2].Split(',');
                            foreach (string nomeCurso in nomesCursos)
                            {
                                if (!todosCursos.ContainsKey(nomeCurso))
                                {
                                    todosCursos[nomeCurso] = new Curso(nomeCurso);
                                }
                                aluno.CursosMatriculados.Add(todosCursos[nomeCurso]);
                                todosCursos[nomeCurso].AlunosMatriculados.Add(aluno);
                            }
                        }
                    }
                }
                
                if (File.Exists(CursosFile))
                {
                    foreach (string linha in File.ReadLines(CursosFile))
                    {
                        string[] partes = linha.Split('|');
                        if (partes.Length > 1)
                        {
                            NomesDosInstrutores nomeInstrutor = (NomesDosInstrutores)Enum.Parse(typeof(NomesDosInstrutores), partes[0], true);
                            var instrutor = instrutores[nomeInstrutor];
                            
                            if (!string.IsNullOrEmpty(partes[1]))
                            {
                                string[] nomesCursos = partes[1].Split(',');
                                foreach (string nomeCurso in nomesCursos)
                                {
                                    if (!todosCursos.ContainsKey(nomeCurso))
                                    {
                                        todosCursos[nomeCurso] = new Curso(nomeCurso);
                                    }
                                    instrutor.CursosMinistrados.Add(todosCursos[nomeCurso]);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao carregar dados: {e.Message}");
            }
        }
    }
}