using System;

public abstract class Goal {
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }

    public abstract void RecordEvent();

    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        return $"[{(IsComplete() ? 'X' : ' ')}] {_shortName} ({_description})";
    }

    public abstract string GetStringRepresentation();

    public string GetShortName()
    {
        return _shortName;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetPoints()
    {
        return _points;
    }

    public virtual event EventHandler<int> OnNegativeEventRecorded;
}