using System;

class Program
{
    static void Main(string[] args)
    {

        Swimming swim = new Swimming("2025-04-12", 20, 30);
        Running run = new Running("2025-04-13", 30, 5.5);
        Cycling bike = new Cycling("2025-04-14", 45, 15.0);

        List<Activity> activities = new List<Activity>();
        activities.Add(run);
        activities.Add(swim);
        activities.Add(bike);

        foreach (Activity activity in activities)
        {
            activity.GetSummary();
        }
    }
}