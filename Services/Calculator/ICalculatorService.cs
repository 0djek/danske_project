using Models.Response;

namespace Services.Calculator;

public interface ICalculatorService
{
    Task<IEnumerable<SortNumbersResponseEntry>> CalculateAndSaveAsync(string numbers);
    Task<string> GetLatestCalculationAsync();
}
