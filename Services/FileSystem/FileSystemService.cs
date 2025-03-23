
namespace Services.FileSystem;

public class FileSystemService : IFileSystemService
{
    public async Task<string> ReadAllTextAsync(string fileName)
    {
        return await File.ReadAllTextAsync(fileName);
    }

    public async Task WriteAllTextAsync(string fileName, string text)
    {
        await File.WriteAllTextAsync(fileName, text);
    }
}
