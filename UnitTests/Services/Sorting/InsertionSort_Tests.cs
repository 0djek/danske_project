using Services.Sorting;

namespace UnitTests.Services.Sorting;

public class InsertionSort_Tests
{
    [Fact]
    public void ReturnsEmptyList_WhenGivenEmptyList()
    {
        var service = new InsertionSortService();
        var result = service.Sort([]);

        Assert.Empty(result);
    }

    [Fact]
    public void ReturnsSortedList()
    {
        var service = new InsertionSortService();
        var result = service.Sort([56, 51, 52]);

        Assert.Equal([51, 52, 56], result);
    }
}
