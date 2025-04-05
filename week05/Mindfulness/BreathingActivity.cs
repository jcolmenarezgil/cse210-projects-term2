public class BreathingActivity : Activity
{
    private const int _inhalationTime = 4;
    private const int _exhalationTime = 6;

    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {

    }
    public void Run()
    {
        DisplayStartingMessage();

        Console.Write("How long, in seconds, would you like for your session? ");
        string inputDuration = Console.ReadLine();

        if (int.TryParse(inputDuration, out int seconds))
        {
            if (seconds > 0)
            {
                _duration = seconds;

                Console.Clear();
                Console.WriteLine("Get Ready...");
                base.ShowSpinner(5);

                int timeElapsed = 0;

                while (timeElapsed < _duration)
                {
                    Console.Write("\nBreathe in...");
                    base.ShowCountDown(_inhalationTime);
                    timeElapsed += _inhalationTime;

                    if (timeElapsed < _duration)
                    {
                        Console.Write("\nNow breathe out...");
                        base.ShowCountDown(_exhalationTime);
                        timeElapsed += _exhalationTime;
                        Console.Write("\n");
                    }
                    else
                    {
                        Console.WriteLine("");
                        break;
                    }
                }
                Console.WriteLine($"\nWell done!!");
                base.ShowSpinner(6);
                DisplayEndingMessage();
                Thread.Sleep(5000);
                Console.Clear();
            }
            else
            {
                Console.WriteLine("The duration must be a positive number.");
            }
        }
        else
        {
            Console.WriteLine("Invalid entry. Please enter a whole number for the duration.");
        }
    }
}