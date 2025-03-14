public class PromptGenerator
{
    /* https://learn.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/tutorials/list-collection */
    public List<string> _prompts = new List<string> {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "Think of your writing today as a time capsule, what things are happening today that you would like to treasure and read in the future?",
        "If you were to tell a story to your future self, how would you narrate your occurrences of today?",
        "Pause and think, what were the most important things that happened in your day today?",
        "Who was the unexpected person who taught you something significant today?",
        "How do you feel writing these words in your journal entry today?"
    };

    public string GetPromptGenerator()
    {
        Random random = new Random();

        int randomIndex = random.Next(_prompts.Count);

        string randomPrompt = _prompts[randomIndex];

        return randomPrompt;
    }
}