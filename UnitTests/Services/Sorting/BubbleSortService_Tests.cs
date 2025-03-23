using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Sorting;

namespace UnitTests.Services.Sorting;

public class BubbleSortService_Tests
{
    [Fact]
    public void ReturnsEmptyList_WhenGivenEmptyList()
    {
        var service = new BubbleSortService();
        var result = service.Sort([]);

        Assert.Empty(result);
    }

    [Fact]
    public void ReturnsSortedList()
    {
        var service = new BubbleSortService();
        var result = service.Sort([56, 51, 52]);

        Assert.Equal([51, 52, 56], result);
    }
}
