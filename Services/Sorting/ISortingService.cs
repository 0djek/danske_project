namespace Services.Sorting;

/// <summary>
/// Service to implement sorting algorithms.
/// </summary>
public interface ISortingService
{
    /// <summary>
    /// Name of the sorting algorithm.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Sorts given numbers and returns sorted result.
    /// </summary>
    /// <param name="numbers">Numbers to sort.</param>
    /// <returns>Sorted numbers.</returns>
    List<int> Sort(List<int> numbers);
}
