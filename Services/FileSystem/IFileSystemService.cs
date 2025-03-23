namespace Services.FileSystem;

public interface IFileSystemService
{
    Task WriteAllTextAsync(string fileName, string text);
    Task<string> ReadAllTextAsync(string fileName);
}
