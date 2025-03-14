public class Entry
{
    public DateTime _date;
    public string _promptText;
    public string _entryText;

    public void Display()
    {
        Console.WriteLine($"{_date.ToString("yyyy-MM-dd HH:mm:ss")}");
        Console.WriteLine($"{_promptText}:");
        Console.WriteLine($"{_entryText}");
    }
}