using System;
using System.Collections.Generic;
using System.Linq;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private List<string> _availableQuestions;
    private Random _random = new Random();

    public ReflectingActivity() : base("Reflecting Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _prompts = new List<string>()
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>()
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        _availableQuestions = new List<string>(_questions);
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

                Console.WriteLine("Consider the following prompt:\n");
                DisplayPrompt();
                Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
                Console.ReadKey();

                Console.WriteLine("\nNow ponder on the following questions as they relate to this experience.");
                Console.Write("You may begin in: ");
                base.ShowCountDown(5);
                Console.Clear();

                while (timeElapsed < _duration)
                {
                    DisplayQuestions();
                    base.ShowSpinner(10);
                    timeElapsed += 10;

                    if (timeElapsed < _duration)
                    {
                        DisplayQuestions();
                        base.ShowSpinner(10);
                        timeElapsed += 10;
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

    public string GetRandomQuestion()
    {
        if (_availableQuestions != null && _availableQuestions.Count > 0)
        {
            int randomIndex = _random.Next(_availableQuestions.Count);
            string selectedQuestion = _availableQuestions[randomIndex];
            _availableQuestions.RemoveAt(randomIndex);
            return selectedQuestion;
        }
        else
        {
            if (_availableQuestions.Count > 0)
            {
                return GetRandomQuestion();
            }
            return "";
        }
    }

    public void DisplayPrompt()
    {
        Console.WriteLine($" --- {GetRandomPrompt()} ---");
    }

    public void DisplayQuestions()
    {
        Console.Write($"> {GetRandomQuestion()} ");
    }
}