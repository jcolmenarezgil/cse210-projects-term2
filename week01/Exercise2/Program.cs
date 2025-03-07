using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please, indicate your rating percentage: ");
        string studentRating = Console.ReadLine();
        int ratingNumber = int.Parse(studentRating);

        if (ratingNumber >= 90)
        {
            string letter = "A";
            Console.WriteLine($"the grade obtained is: {letter}");
        }
        else if (ratingNumber >= 80)
        {
            string letter = "B";
            Console.WriteLine($"the grade obtained is: {letter}");
        }
        else if (ratingNumber >= 70)
        {
            string letter = "C";
            Console.WriteLine($"the grade obtained is: {letter}");
        }
        else if (ratingNumber >= 60)
        {
            string letter = "D";
            Console.WriteLine($"the grade obtained is: {letter}");
        }
        else
        {
            string letter = "F";
            Console.WriteLine($"So bad, that the score obtained is less than 60%, its qualification: {letter}");
        }

        if (ratingNumber > 70)
        {
            Console.WriteLine("Congratulations you passed the course!");
        }
        else
        {
            Console.WriteLine("Unfortunately, you have not passed this course. You must retake this course.");
        }
    }
}