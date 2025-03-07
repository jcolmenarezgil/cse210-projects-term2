using System;

class Program
{
    static void Main(string[] args)
    {
        int guessNumber = 0;

        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 11);

        //Console.Write("What is the magic number?: ");
        //string userNumber = Console.ReadLine();
        //magicNumber = int.Parse(userNumber);

        while (magicNumber != guessNumber)
        {
            Console.Write("What is your guess? ");
            string userGuess = Console.ReadLine();
            guessNumber = int.Parse(userGuess);

            if (magicNumber < guessNumber) Console.WriteLine("Lower");
            else Console.WriteLine("Higher");
        }
        Console.Write("You guessed it!");
    }
}