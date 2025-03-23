namespace Models.Response;

public class SortNumbersResponseEntry(string sortName, TimeSpan timeSpan)
{
    public string SortName { get; set; } = sortName;

    public TimeSpan TimeSpan { get; set; } = timeSpan;
}
