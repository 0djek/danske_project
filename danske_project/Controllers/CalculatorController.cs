using Microsoft.AspNetCore.Mvc;
using Models.Response;
using Services.Calculator;

namespace danske_project.Controllers;

[Route("api/calculator")]
[ApiController]
public class CalculatorController(ICalculatorService calculator) : ControllerBase
{
    private readonly ICalculatorService _calculator = calculator;

    /// <summary>
    /// Sorts given numbers using registered sorting algorithms.
    /// </summary>
    /// <param name="numbers">Numbers to sort.</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IEnumerable<SortNumbersResponseEntry>> CalculateAsync(string numbers)
    {
        var response = await _calculator.CalculateAndSaveAsync(numbers);
        return response;
    }

    [HttpGet]
    public async Task<string> GetLatestAsync()
    {
        return await _calculator.GetLatestCalculationAsync();
    }
}
