using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static public void Main(string[] args)
    {
        Journal journal = new Journal();

        {
            Console.WriteLine("Journal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Show the journal");
            Console.WriteLine("3. Save the journal");
            Console.WriteLine("4. Load the journal");
            Console.WriteLine("5. Quit");

            int menu_input = 0;
            menu_input = int.Parse(Console.ReadLine());

            if (menu_input == 1)
            {
               journal.AddEntry();
            }

            else if (menu_input == 2)
            {
                journal.ShowJournal();
            }

            else if (menu_input == 3)
            {
                
            }

            else if (menu_input == 4)
            {
                
            }

            else
            {
            
            }
        }
    }
}

class Prompt
{
    public string text { get; set; }

    public Prompt(string text)
    {
        this.text = text;
    }
}

class Entry
{
    public string text { get; set; }
    public string prompt { get; set; }
    public DateTime date { get; set; }

    public Entry(string text, string prompt, DateTime date)
    {
        this.text = text;
        this.prompt = prompt;
        this.date = date;
    }
}

class Journal
{
    List<Entry> entries = new List<Entry>();
    List<Prompt> prompts = new List<Prompt>()
    {
        new Prompt("Who was the most interesting person I interacted with today?"),
        new Prompt("What was the best part of my day?"),
        new Prompt("How did I see the hand of the Lord in my life today?"),
        new Prompt("What was the strongest emotion I felt today?"),
        new Prompt("If I had one thing I could do over today, what would it be?")
    };

    public void AddEntry()
    {
        Random rnd = new Random();
        int index = rnd.Next(prompts.Count);
        Console.WriteLine(prompts[index].text);

        string response = Console.ReadLine();
        entries.Add(new Entry(response, prompts[index].text, DateTime.Now));
    }

    public void ShowJournal()
    {
        Console.WriteLine("Journal Entries: ");
        foreach (var entry in entries)
        {
            Console.WriteLine($"{entry.date} - {entry.prompt}");
            Console.WriteLine(entry.text);
            Console.WriteLine();
        }
    }

    public void SaveJournal(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine(entry.date);
                writer.WriteLine(entry.prompt);
                writer.WriteLine(entry.text);
            }
        }
    }

    public void LoadJournal(string filename)
    {
        entries.Clear();
        using (StreamReader reader = new StreamReader(filename))
        {
            while (!reader.EndOfStream)
            {
                DateTime date = DateTime.Parse(reader.ReadLine());
                string prompt = reader.ReadLine();
                string text = reader.ReadLine();

                entries.Add(new Entry(text, prompt, date));
            }
        }
    }
}