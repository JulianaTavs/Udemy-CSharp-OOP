using Ex27;

ValidatingData validatingData = new ValidatingData();
CsvProcessor csvProcessor = new CsvProcessor();

string inputFilePath = validatingData.GetAValidCsvFilePath("Enter the full path of the input .csv " +
"file(e.g., C:\\temp\\items.csv): ", "Invalid file path or file does not exist. Please enter a " +
"valid .csv file path.");

List<Item> items = csvProcessor.ReadItemsFromCsv(inputFilePath);

if (items.Count > 0)
{
    string inputDirectory = Path.GetDirectoryName(inputFilePath);
    string outputFolderPath = Path.Combine(inputDirectory, "out");

    csvProcessor.SaveSummaryCsv(items, outputFolderPath);
}
else
{
    Console.WriteLine("Nenhum item foi lido do arquivo CSV ou o arquivo está vazio.");
}

Console.ReadKey(); // Para manter o console aberto após a execução
