using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        PromptGenerator promptGenerator = new PromptGenerator();
        string promptText = promptGenerator.GetPromptGenerator();

        Console.WriteLine(promptText);
        Console.Write($"> ");
        string userEntry = Console.ReadLine();

        DateTime dateTimeNow = DateTime.Now;

        newEntry._promptText = promptText;
        newEntry._entryText = userEntry;
        newEntry._date = dateTimeNow;

        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            outputFile.WriteLine("Date,Prompt,Entry");
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date.ToString("yyyy-MM-dd HH:mm:ss")},{EscapeCsv(entry._promptText)},{EscapeCsv(entry._entryText)}");
            }
        }
    }

    private string EscapeCsv(string text)
    {
        if (text.Contains(",") || text.Contains("\""))
        {
            return $"\"{text.Replace("\"", "\"\"")}\"";
        }
        return text;
    }

    public void LoadFromFile(string file)
    {
        _entries.Clear();

        string[] lines = System.IO.File.ReadAllLines(file);

        if (lines.Length > 1)
        {
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = ParseCsv(lines[i]);

                if (parts.Length == 3)
                {
                    DateTime date = DateTime.Parse(parts[0]);
                    string promptText = parts[1];
                    string entryText = parts[2];

                    Entry newEntry = new Entry();
                    newEntry._date = date;
                    newEntry._promptText = promptText;
                    newEntry._entryText = entryText;

                    _entries.Add(newEntry);
                }
            }
        }
    }

    private string[] ParseCsv(string line)
    {
        List<string> parts = new List<string>();
        bool inQuotes = false;
        string currentPart = "";

        for (int i = 0; i < line.Length; i++)
        {
            if (line[i] == '\"')
            {
                if (inQuotes && i + 1 < line.Length && line[i + 1] == '\"')
                {
                    currentPart += '\"';
                    i++;
                }
                else
                {
                    inQuotes = !inQuotes;
                }
            }
            else if (line[i] == ',' && !inQuotes)
            {
                parts.Add(currentPart);
                currentPart = "";
            }
            else
            {
                currentPart += line[i];
            }
        }
        parts.Add(currentPart);
        return parts.ToArray();
    }
}