using System;

public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        Console.Write($"How many points do you want to subtract by '{_shortName}'? ");
        if (int.TryParse(Console.ReadLine(), out int pointsToSubtract))
        {
            Console.WriteLine($"Negative event recorded for '{_shortName}'. An attempt will be made to subtract {pointsToSubtract} points.");
            OnNegativeEventRecorded?.Invoke(this, pointsToSubtract);
        }
        else
        {
            Console.WriteLine("Invalid entry. No points were deducted.");
        }
    }

    public override bool IsComplete()
    {
        return false; // Negative goals are never complete
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{_shortName}:{_description}:{_points}";
    }

    public override string GetDetailsString()
    {
        return $"\u001b[31m[-] {_shortName} ({_description})\u001b[0m"; 
    }

    public override event EventHandler<int> OnNegativeEventRecorded;
}