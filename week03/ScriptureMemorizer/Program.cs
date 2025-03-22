using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("John", 3, 16);

        string scriptureText = "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";

        Scripture scripture = new Scripture(reference, scriptureText);

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetScriptureText());
            Console.WriteLine("Press Enter Key or Type 'quit' for Exit.");
            string inputUser = Console.ReadLine();

            if (inputUser.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }
        Console.WriteLine("All words its hidden, try to guess or repeat");
    }
}