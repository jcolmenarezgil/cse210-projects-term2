public class Cycling : Activity
{
    private double _speed;

    public Cycling(string date, double minutes, double speed) : base(date, minutes)
    {
        _speed = speed;
        Type = "Cycling";
    }

    public override double GetDistance()
    {
        return _speed * Minutes / 60;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return Minutes > 0 ? 60 / _speed : 0;
    }
}