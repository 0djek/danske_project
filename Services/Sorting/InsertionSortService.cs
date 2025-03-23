
namespace Services.Sorting;

public class InsertionSortService : ISortingService
{
    public string Name => "InsertionSort";

    public List<int> Sort(List<int> numbers)
    {
        for (int i = 1; i < numbers.Count; i++)
        {
            var val = numbers[i];
            for (int j = i - 1; j >= 0;)
            {
                if (val < numbers[j])
                {
                    numbers[j + 1] = numbers[j];
                    j--;
                    numbers[j + 1] = val;
                }
                else
                {
                    break;
                }
            }
        }

        return numbers;
    }
}
