using System;


class Program
{
    static void Main(string[] args)
    {
        // set the end number
        int endNumber = 5;
        // Define a local variable for 'Journal Class'
        Journal journal = new Journal();

        while (true)
        {
            // Main menu user
            Console.WriteLine("JOURNAL - MAIN MENU ");
            Console.WriteLine("1. Write a new entry.");
            Console.WriteLine("2. Display all entries.");
            Console.WriteLine("3. Save all entries.");
            Console.WriteLine("4. Load all entries.");
            Console.WriteLine("5. Quit/ Exit.");

            // Ask option from user
            Console.Write($"\nChoose one option to start: ");
            string userNumber = Console.ReadLine();
            int userChoice = int.Parse(userNumber);

            //https://learn.microsoft.com/es-es/dotnet/csharp/language-reference/statements/selection-statements
            switch (userChoice)
            {
                case 1:
                    Entry newEntry = new Entry();
                    journal.AddEntry(newEntry);
                    break;

                case 2:
                    journal.DisplayAll();
                    break;

                case 3:
                    journal.SaveToFile("journal.csv");
                    break;

                case 4:
                    journal.LoadFromFile("journal.csv");
                    break;
                case 5:
                    break;

                default:
                    Console.WriteLine("Sorry, the entered number does not match with any option!");
                    break;
            }

            if (userChoice == endNumber)
            {
                break;
            }
        }
        Console.WriteLine("See you next time.");
    }
}