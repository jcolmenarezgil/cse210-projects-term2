public class ActivityStats
{
    public int Count { get; set; }
    public int TotalSeconds { get; set; }

    public ActivityStats()
    {
        Count = 0;
        TotalSeconds = 0;
    }
}