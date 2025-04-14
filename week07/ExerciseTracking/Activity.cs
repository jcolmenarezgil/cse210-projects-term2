using System;

public abstract class Activity 
{
    private string _date;
    private double _minutes;
    private string _type;


    public Activity(string date, double minutes)
    {
        _date = FormatDate(date);
        _minutes = minutes;
    }

    public string Date
    {
        get { return _date; }
        protected set { _date = FormatDate(value); }
    }

    public double Minutes
    {
        get { return _minutes; }
        protected set { _minutes = value; }
    }
    public string Type
    {
        get { return _type; }
        protected set { _type = value; }
    }
    private string FormatDate(string date)
    {
        if (DateTime.TryParse(date, out DateTime thisDate))
        {
            return thisDate.ToString("d MMM yyyy");
        }
        else
        {
            return "Invalid date format";
        }
    }

    public string GetDate()
    {
        return _date;
    }

    public void SetType(string type)
    {
        _type = type;
    }
    public string GetType()
    {
        return _type;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public void GetSummary()
    {
        Console.WriteLine($"{GetDate()} {GetType()}: Distance: {GetDistance():F2} km, Speed: {GetSpeed():F2} km/h, Pace: {GetPace():F2} min per km");
    }
}
