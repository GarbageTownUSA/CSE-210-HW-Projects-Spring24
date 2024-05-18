using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        LoadJournal(journal);

        while (true)
        {
            Console.WriteLine("Journal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Show the journal");
            Console.WriteLine("3. Save the journal");
            Console.WriteLine("4. Load the journal");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");

            if (!int.TryParse(Console.ReadLine(), out int menuInput) || menuInput < 1 || menuInput > 5)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                continue;
            }

            switch (menuInput)
            {
                case 1:
                    journal.AddEntry();
                    break;
                case 2:
                    journal.ShowJournal();
                    break;
                case 3:
                    SaveJournal(journal);
                    break;
                case 4:
                    LoadJournal(journal);
                    break;
                case 5:
                    Console.WriteLine("Goodbye!");
                    return;
            }
        }
    }

    static void LoadJournal(Journal journal)
    {
        Console.Write("Enter filename to load the journal: ");
        string loadFilename = Console.ReadLine();
        if (File.Exists(loadFilename))
        {
            journal.LoadJournal(loadFilename);
            Console.WriteLine("Journal loaded successfully.");
        }
        else
        {
            Console.WriteLine("File not found. Journal remains unchanged.");
        }
    }

    static void SaveJournal(Journal journal)
    {
        Console.Write("Enter filename to save the journal: ");
        string saveFilename = Console.ReadLine();
        if (journal.SaveJournal(saveFilename))
            Console.WriteLine("Journal saved successfully.");
        else
            Console.WriteLine("Failed to save the journal.");
    }
}

class Entry
{
    public string Text { get; }
    public string Prompt { get; }
    public string Date { get; }

    public Entry(string text, string prompt, string date)
    {
        Text = text;
        Prompt = prompt;
        Date = date;
    }

    public override string ToString()
    {
        return $"{Date}|{Prompt}|{Text}";
    }
}

class Journal
{
    private List<Entry> entries = new List<Entry>();
    private readonly List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public void AddEntry()
    {
        Random rnd = new Random();
        string prompt = prompts[rnd.Next(prompts.Count)];
        Console.WriteLine(prompt);
        string response = Console.ReadLine();
        entries.Add(new Entry(response, prompt, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
    }

    public void ShowJournal()
    {
        Console.WriteLine("Journal Entries:");
        foreach (var entry in entries)
        {
            Console.WriteLine($"{entry.Date} - {entry.Prompt}");
            Console.WriteLine(entry.Text);
            Console.WriteLine();
        }
    }

    public bool SaveJournal(string filename)
    {
        try
        {
            File.WriteAllLines(filename, entries.ConvertAll(e => e.ToString()));
            return true;
        }
        catch
        {
            return false;
        }
    }

    public void LoadJournal(string filename)
    {
        entries.Clear();
        foreach (var line in File.ReadAllLines(filename))
        {
            var parts = line.Split('|');
            if (parts.Length == 3)
                entries.Add(new Entry(parts[2], parts[1], parts[0]));
        }
    }
}
