using Services.Calculator;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace Microsoft.Extensions.DependencyInjection;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class Calculator
{
    public static IServiceCollection RegisterCalculator(this IServiceCollection services)
    {
        services.AddScoped<ICalculatorService, CalculatorService>();

        return services;
    }
}
