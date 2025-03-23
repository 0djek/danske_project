using NSubstitute;
using Services.Calculator;
using Services.FileSystem;
using Services.Sorting;

namespace UnitTests.Services.Calculator;

public class CalculatorService_CalculateAndSave_Tests
{
    [Fact]
    public async Task ThrowsOutOfRangeException_WhenEmptyLine()
    {
        CalculatorService service = new([], Substitute.For<IFileSystemService>());

        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => service.CalculateAndSaveAsync(""));
    }

    [Theory]
    [InlineData("0,1")]
    [InlineData("data")]
    [InlineData("test")]
    public async Task ThrowsFormatException_GivenInvalidLine(string line)
    {
        CalculatorService service = new([], Substitute.For<IFileSystemService>());

        await Assert.ThrowsAsync<FormatException>(() => service.CalculateAndSaveAsync(line));
    }

    [Fact]
    public async Task InvokesSavingWithEmptyLine_WhenNoSorters()
    {
        var fileSystemMock = Substitute.For<IFileSystemService>();

        CalculatorService service = new([], fileSystemMock);
        await service.CalculateAndSaveAsync("0 1 2 3");

        await fileSystemMock.Received(1).WriteAllTextAsync(Arg.Any<string>(), Arg.Any<string>());
    }

    [Fact]
    public async Task SavesSortedLine()
    {
        var sorter = Substitute.For<ISortingService>();
        sorter.Sort(Arg.Any<List<int>>()).Returns([0, 1, 3, 4]);
        var fileSystemMock = Substitute.For<IFileSystemService>();

        CalculatorService service = new([sorter], fileSystemMock);
        await service.CalculateAndSaveAsync("0 1 4 3");

        await fileSystemMock.Received(1).WriteAllTextAsync(Arg.Any<string>(), "0 1 3 4");
    }

    [Fact]
    public async Task InvokesSortingWithCorrectlyParsedNumbers()
    {
        var sorter = Substitute.For<ISortingService>();
        sorter.Sort(Arg.Any<List<int>>()).Returns([0, 1, 3, 4]);
        var fileSystemMock = Substitute.For<IFileSystemService>();

        CalculatorService service = new([sorter], fileSystemMock);
        await service.CalculateAndSaveAsync("0 1 4 3");

        sorter.Received(1).Sort(Arg.Any<List<int>>());
    }
}
