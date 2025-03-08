using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {

        int endNumber = 0;
        int addNumber;
        int sum = 0;
        int LargestNumber = int.MinValue;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        List<int> List = new List<int>();

        while (true)
        {
            Console.Write("Enter number: ");
            string userNumber = Console.ReadLine();
            addNumber = int.Parse(userNumber);

            if (addNumber == endNumber)
            {
                break;
            }

            List.Add(addNumber);
            sum += addNumber;

            if (addNumber > LargestNumber)
            {
                LargestNumber = addNumber;
            }
        }
        if (List.Count > 0)
        {
            double average = (double)sum / List.Count;

            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine($"The average is: {average}");
            Console.WriteLine($"The largest number is: {LargestNumber}");
        }
    }
}