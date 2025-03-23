using Services.FileSystem;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace Microsoft.Extensions.DependencyInjection;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class FileSystem
{
    public static IServiceCollection RegisterFileSystem(this IServiceCollection services)
    {
        services.AddScoped<IFileSystemService, FileSystemService>();

        return services;
    }
}
