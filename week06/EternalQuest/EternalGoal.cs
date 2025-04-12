// EternalGoal.cs
using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
        // No additional initialization needed for EternalGoal
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"Event recorded for eternal goal: {_shortName}. Points awarded: {_points}");
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_shortName}:{_description}:{_points}";
    }
}