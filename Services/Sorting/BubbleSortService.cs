namespace Services.Sorting;

public class BubbleSortService : ISortingService
{
    public string Name => "BubbleSort";

    public List<int> Sort(List<int> numbers)
    {
        for (int i = 0; i < numbers.Count; i++)
        {
            for (int j = 0; j < numbers.Count - 1; j++)
            {
                if (numbers[j] > numbers[j + 1])
                {
                    (numbers[j], numbers[j + 1]) = (numbers[j + 1], numbers[j]);
                }
            }
        }

        return numbers;
    }
}
