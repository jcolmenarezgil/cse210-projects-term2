using System;
using System.Collections.Generic;
using System.Diagnostics;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;
    private Random _random = new Random();

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string>()
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
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

                Console.WriteLine("List as many responses you can to the following prompt\n");
                DisplayPrompt();
                Console.Write("You may begin in: ");
                base.ShowCountDown(5);

                Console.Write("\n> ");
                List<string> items = GetListFromUser(out int finalTimeElapsed);
                _count = items.Count;
                _duration = finalTimeElapsed;

                Console.WriteLine($"\nYou listed {_count} items!");

                Console.WriteLine($"\nWell done!!");
                base.ShowSpinner(6);
                DisplayEndingMessage();
                base.ShowSpinner(5);
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

    public string GetRandomPrompt()
    {
        if (_prompts != null && _prompts.Count > 0)
        {
            int index = _random.Next(_prompts.Count);
            return _prompts[index];
        }
        return "";
    }

    public void DisplayPrompt()
    {
        Console.WriteLine($" --- {GetRandomPrompt()} ---");
    }

    public List<string> GetListFromUser(out int totalTimeElapsed)
    {
        List<string> items = new List<string>();
        string input;
        totalTimeElapsed = 0;
        Stopwatch stopwatch = new Stopwatch();

        while (totalTimeElapsed < _duration)
        {
            stopwatch.Start();
            input = Console.ReadLine();
            stopwatch.Stop();
            int timeTaken = (int)stopwatch.ElapsedMilliseconds / 1000;
            stopwatch.Reset();

            if (input.ToLower() == "done")
            {
                break;
            }
            if (!string.IsNullOrWhiteSpace(input))
            {
                items.Add(input);
                totalTimeElapsed += timeTaken;
                if (totalTimeElapsed < _duration)
                {
                    Console.Write("> ");
                }
                else
                {
                    Console.Write("> ");
                }

                if (totalTimeElapsed >= _duration)
                {
                    break;
                }
            }
        }
        return items;
    }
}