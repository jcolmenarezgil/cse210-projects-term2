using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        string choice = "";
        while (choice != "7")
        {
            Console.WriteLine("\nEternal Quest Menu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List All Goals");
            Console.WriteLine("3. Record an Event");
            Console.WriteLine("4. Save Goals to file");
            Console.WriteLine("5. Load Goals from file");
            Console.WriteLine("6. Create New Negative Goal");
            Console.WriteLine("7. Exit");

            Console.Write("\nPlease enter your choice: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    RecordEvent();
                    break;
                case "4":
                    SaveGoals();
                    break;
                case "5":
                    LoadGoals();
                    break;
                case "6":
                    CreateNegativeGoal();
                    break;
                case "7":
                    Console.WriteLine("Thank you for participating, Now is Exiting the program.");
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }

            DisplayPlayerInfo();
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYour current score is: {_score}");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("\nGoals:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            return;
        }
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nGoals:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            return;
        }
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("\nWhich type of goal would you like to create? ");
        string goalType = Console.ReadLine();

        Console.Write("\nWhat is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("\nWhat is a short description of your goal? ");
        string description = Console.ReadLine();

        Console.Write("\nWhat is the amount of points associated with this goal? ");
        if (!int.TryParse(Console.ReadLine(), out int points))
        {
            Console.WriteLine("Invalid input for points. Goal creation failed.");
            return;
        }

        switch (goalType)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                Console.WriteLine("Simple goal created successfully!");
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                Console.WriteLine("Eternal goal created successfully!");
                break;
            case "3":
                Console.Write("\nWhat is the target number of times for this goal? ");
                if (!int.TryParse(Console.ReadLine(), out int target))
                {
                    Console.WriteLine("Invalid input for target. Goal creation failed.");
                    return;
                }
                Console.Write("\nWhat is the bonus points for accomplishing this goal the target number of times? ");
                if (!int.TryParse(Console.ReadLine(), out int bonus))
                {
                    Console.WriteLine("Invalid input for bonus points. Goal creation failed.");
                    return;
                }
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                Console.WriteLine("Checklist goal created successfully!");
                break;
            default:
                Console.WriteLine("Invalid goal type selected. Goal creation failed.");
                break;
        }
    }

    public void RecordEvent()
    {
        ListGoalNames();
        if (_goals.Count == 0)
        {
            return;
        }
        Console.Write("\nWhich goal did you accomplish? (Enter the number) ");
        if (int.TryParse(Console.ReadLine(), out int goalNumber) && goalNumber > 0 && goalNumber <= _goals.Count)
        {
            Goal goalToRecord = _goals[goalNumber - 1];
            goalToRecord.RecordEvent();

            if (goalToRecord is ChecklistGoal checklistGoal)
            {
                _score += goalToRecord.GetPoints();
                if (checklistGoal.IsComplete())
                {
                    _score += checklistGoal.GetBonus();
                    Console.WriteLine($"\nCongratulations! You reached the target for '{goalToRecord.GetShortName()}' and earned a bonus of {checklistGoal.GetBonus()} points!");
                }
            }
            else if (goalToRecord is EternalGoal eternalGoal)
            {
                _score += eternalGoal.GetPoints();
            }
            else if (goalToRecord is SimpleGoal simpleGoal)
            {
                if (!simpleGoal.IsComplete())
                {
                    _score += goalToRecord.GetPoints();
                }
            }
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("\nWhat is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully!");
    }

    public void LoadGoals()
    {
        Console.Write("\nWhat is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            _goals.Clear();
            using (StreamReader inputFile = new StreamReader(filename))
            {
                if (!inputFile.EndOfStream && int.TryParse(inputFile.ReadLine(), out int score))
                {
                    _score = score;
                }
                else
                {
                    Console.WriteLine("Error loading score. Setting score to 0.");
                    _score = 0;
                }

                while (!inputFile.EndOfStream)
                {
                    string line = inputFile.ReadLine();
                    string[] parts = line.Split(':');

                    if (parts.Length > 0)
                    {
                        string goalType = parts[0];
                        string name = parts[1];
                        string description = parts[2];
                        int points = int.Parse(parts[3]);

                        switch (goalType)
                        {
                            case "SimpleGoal":
                                bool isComplete = bool.Parse(parts[4]);
                                SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
                                if (isComplete)
                                {
                                    simpleGoal.RecordEvent();
                                }
                                _goals.Add(simpleGoal);
                                break;
                            case "EternalGoal":
                                _goals.Add(new EternalGoal(name, description, points));
                                break;
                            case "ChecklistGoal":
                                int target = int.Parse(parts[4]);
                                int bonus = int.Parse(parts[5]);
                                int amountCompleted = int.Parse(parts[6]);
                                ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, target, bonus);
                                for (int i = 0; i < amountCompleted; i++)
                                {
                                    checklistGoal.RecordEvent();
                                }
                                _goals.Add(checklistGoal);
                                break;
                            case "NegativeGoal":
                                NegativeGoal negativeGoal = new NegativeGoal(name, description, points);
                                negativeGoal.OnNegativeEventRecorded += HandleNegativeEvent;
                                _goals.Add(negativeGoal);
                                break;
                            default:
                                Console.WriteLine($"Unknown goal type: {goalType}. Skipping.");
                                break;
                        }
                    }
                }
            }
            Console.WriteLine("Goals loaded successfully!");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }

    public void CreateNegativeGoal()
    {
        Console.Write("\nWhat is the name of your negative goal? ");
        string name = Console.ReadLine();

        Console.Write("\nWhat is a short description of your negative goal? ");
        string description = Console.ReadLine();

        Console.Write("\nWhat is the amount of points associated with this negative goal (points to be subtracted)? ");
        if (!int.TryParse(Console.ReadLine(), out int points))
        {
            Console.WriteLine("Invalid input for points. Negative goal creation failed.");
            return;
        }

        NegativeGoal negativeGoal = new NegativeGoal(name, description, -points);
        negativeGoal.OnNegativeEventRecorded += HandleNegativeEvent;
        _goals.Add(negativeGoal);
        Console.WriteLine("Negative goal created successfully!");
    }

    private void HandleNegativeEvent(object sender, int pointsToSubtract)
    {
        if (sender is NegativeGoal negativeGoal)
        {
            _score += pointsToSubtract;
            Console.WriteLine($"\u001b[31mHave been subtracted {pointsToSubtract} by the Negative Goal called '{negativeGoal.GetShortName()}'\u001b[0m. Remaining cumulative total: {_score}");
        }
    }
}