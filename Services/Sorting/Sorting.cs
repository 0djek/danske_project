using Services.Sorting;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace Microsoft.Extensions.DependencyInjection;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class Sorting
{
    public static IServiceCollection RegisterSorters(this IServiceCollection services)
    {
        services.AddScoped<ISortingService, BubbleSortService>();
        services.AddScoped<ISortingService, InsertionSortService>();

        return services;
    }
}
