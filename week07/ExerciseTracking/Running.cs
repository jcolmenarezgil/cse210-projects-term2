public class Running : Activity
{
    private double _distance;

    public Running(string date, double minutes, double distance) : base(date, minutes)
    {
        _distance = distance;
        Type = "Running";
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return Minutes > 0 ? _distance / Minutes * 60 : 0;
    }

    public override double GetPace()
    {
        return _distance > 0 ? Minutes / _distance : 0;
    }   
}