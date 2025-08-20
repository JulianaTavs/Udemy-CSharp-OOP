namespace Ex36
{
    public static class GerenciadorDeArquivos
    {
        static readonly string path = "dadosVotacao.txt";
        static public void GravarDados(string nome, int qtdeVotos)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    string linha = $"{nome},{qtdeVotos}";

                    sw.WriteLine(linha);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}