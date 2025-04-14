public class Swimming : Activity
{
    private double _numberOfLaps;

    public Swimming(string date, double minutes, double numberOfLaps) : base(date, minutes)
    {
        _numberOfLaps = numberOfLaps;
        Type = "Swimming";
    }

    public override double GetDistance()
    {
        return _numberOfLaps * 0.050;
    }

    public override double GetSpeed()
    {
        return Minutes > 0 ? GetDistance() / Minutes * 60 : 0;
    }

    public override double GetPace()
    {
        return GetDistance() > 0 ? Minutes / GetDistance() : 0;
    }
}