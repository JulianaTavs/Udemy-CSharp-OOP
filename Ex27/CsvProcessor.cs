using System.Globalization;

namespace Ex27
{
    class CsvProcessor
    {
        //Método para ler itens de um arquivo CSV de entrada:
        public List<Item> ReadItemsFromCsv(string filePath)
        {
            List<Item> items = new List<Item>();
            try
            {
                //Usando o StreamReader para ler o arquivo linha por linha:
                using (StreamReader sr = new StreamReader(filePath))
                {
                    sr.ReadLine(); // Pula a primeira linha (o cabeçalho)
                    
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] fields = line.Split(','); //Divide a linha por campos 
                                                           // separados por vírgula.

                        //Validação básica para garantir que temos 3 campos:
                        if (fields.Length == 3)
                        {
                            string name = fields[0].Trim();
                            decimal price = decimal.Parse(fields[1].Trim(),
                            CultureInfo.InvariantCulture);
                            int quantity = int.Parse(fields[2].Trim());

                            items.Add(new Item(name, price, quantity));
                        }
                        else
                        {
                            Console.WriteLine($"Atenção: Linha mal formatada ignorada no arquivo " +
                            $"CSV:{line}");
                        }
                    }
                }
                Console.WriteLine($"\nDados dos itens lidos com sucesso de: {filePath}");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Erro: O arquivo '{filePath}' não foi encontrado.");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Erro no formato nos dados do CSV: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro inesperado ao ler o arquivo: {ex.Message}");
            }
            return items;
        }

        // Método para salvar o resumo dos itens em um novo arquivo CSV:
        public void SaveSummaryCsv(List<Item> items, string outputFolderPath)
        {
            //Cria a subpasta "out" se ela não existir:
            Directory.CreateDirectory(outputFolderPath);

            string outputFilePath = Path.Combine(outputFolderPath, "summary.csv");
            try
            {
                // O 'using' garante que o StreamWriter será fechado e os recursos liberados
                using (StreamWriter sw = new StreamWriter(outputFilePath))
                {
                    // Escreve o cabeçalho (opcional, mas boa prática)
                    sw.WriteLine("Name,TotalPrice");

                    // Itera sobre cada item na lista e escreve no arquivo
                    foreach (Item item in items)
                    {
                        sw.WriteLine(item.ToSummaryCsvString());
                    }
                }
                Console.WriteLine("\nArquivo de resumo 'summary.csv' criado com sucesso em: " +
                $"{outputFilePath}");
            }
            catch (IOException e)
            {
                Console.WriteLine($"Ocorreu um erro ao salvar o arquivo: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ocorreu um erro inesperado: {e.Message}");
            }
        }
    }
}

