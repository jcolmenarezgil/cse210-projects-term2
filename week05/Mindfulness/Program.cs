using System;

class Program
{
    private static Dictionary<string, ActivityStats> _activityStatistics = new Dictionary<string, ActivityStats>();
    static void Main(string[] args)
    {
        _activityStatistics["Breathing Activity"] = new ActivityStats();
        _activityStatistics["Reflecting Activity"] = new ActivityStats();
        _activityStatistics["Listing Activity"] = new ActivityStats();

        while (true)
        {

            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflecting activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. Statistics");
            Console.WriteLine("5. Exit");
            Console.Write("\nSelect an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.Run();
                    UpdateStatistics(breathingActivity.GetName(), breathingActivity.GetDuration());
                    break;
                case "2":
                    ReflectingActivity reflectingActivity = new ReflectingActivity();
                    reflectingActivity.Run();
                    UpdateStatistics(reflectingActivity.GetName(), reflectingActivity.GetDuration());
                    break;
                case "3":
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.Run();
                    UpdateStatistics(listingActivity.GetName(), listingActivity.GetDuration());
                    break;
                case "4":
                    DisplayStatistics();
                    break;
                case "5":
                    Console.Clear();
                    Console.WriteLine("\nExiting Program...");
                    Thread.Sleep(3000);
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("\nInvalid selection. Please enter a number between");
                    break;
            }
        }
    }

    private static void UpdateStatistics(string activityName, int duration)
    {
        if (_activityStatistics.ContainsKey(activityName))
        {
            _activityStatistics[activityName].Count++;
            _activityStatistics[activityName].TotalSeconds += duration;
        }
    }

    private static void DisplayStatistics()
    {
        Console.Clear();
        Console.WriteLine("\n--- Activity Statistics ---");
        foreach (var pair in _activityStatistics)
        {
            Console.WriteLine($"{pair.Key}:");
            Console.WriteLine($"  Times Completed: {pair.Value.Count}");
            Console.WriteLine($"  Total Seconds: {pair.Value.TotalSeconds}");
            Console.WriteLine($"  Total Minutes: {pair.Value.TotalSeconds / 60}");
            Console.WriteLine();
        }
        Console.WriteLine("Press any key to return to the main menu.");
        Console.ReadKey();
        Console.Clear();
    }
}