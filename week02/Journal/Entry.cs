using System;

public class Entry
{
    public string Date { get; private set; }
    public string PromptText { get; private set; }
    public string EntryText { get; private set; }
    public string Mood { get; private set; }
    public string Location { get; private set; }

    public Entry(string date, string promptText, string entryText, string mood, string location)
    {
        Date = date;
        PromptText = promptText;
        EntryText = entryText;
        Mood = mood;
        Location = location;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {PromptText}");
        Console.WriteLine($"Entry: {EntryText}");
        Console.WriteLine($"Mood: {Mood}");
        Console.WriteLine($"Location: {Location}");
    }
}
