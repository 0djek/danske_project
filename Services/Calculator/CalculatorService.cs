using System.Diagnostics;
using Models.Response;
using Services.FileSystem;
using Services.Sorting;

namespace Services.Calculator;

public class CalculatorService(IEnumerable<ISortingService> sortingServices, IFileSystemService fileSystem) : ICalculatorService
{
    private readonly IEnumerable<ISortingService> _sortingServices = sortingServices;
    private readonly IFileSystemService _fileSystem = fileSystem;
    private const string _resultsFileName = "result.txt";

    public async Task<IEnumerable<SortNumbersResponseEntry>> CalculateAndSaveAsync(string line)
    {
        ArgumentOutOfRangeException.ThrowIfEqual(line, string.Empty);

        var numbers = ParseLineToNumbers(line);

        var responseEntries = new List<SortNumbersResponseEntry>();
        List<int> sortedToSave = [];

        var watch = Stopwatch.StartNew();
        watch.Reset();

        foreach (ISortingService sorter in _sortingServices)
        {
            watch.Start();
            sortedToSave = sorter.Sort(numbers);
            watch.Stop();

            var elapsed = watch.Elapsed;
            responseEntries.Add(new(sorter.Name, elapsed));

            watch.Reset();
        }

        var stringified = string.Join(" ", sortedToSave);
        await _fileSystem.WriteAllTextAsync(_resultsFileName, stringified);
        return responseEntries;
    }

    private static List<int> ParseLineToNumbers(string line)
    {
        var numbers = line.Split(' ');
        List<int> result = [];

        foreach (var number in numbers)
        {
            var parsed = int.Parse(number);
            result.Add(parsed);
        }

        return result;
    }

    public async Task<string> GetLatestCalculationAsync()
    {
        var numbers = await _fileSystem.ReadAllTextAsync(_resultsFileName);
        return numbers;
    }
}
