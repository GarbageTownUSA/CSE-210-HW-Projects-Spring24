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
