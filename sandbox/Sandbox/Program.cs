using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class ScriptureReference
{
    public string Book { get; private set; }
    public string Chapter { get; private set; }
    public string StartVerse { get; private set; }
    public string EndVerse { get; private set; }

    public ScriptureReference(string reference)
    {
        if (reference.Contains("-"))
        {
            var parts = reference.Split(new[] { ':', '-' });
            Book = parts[0].Split(' ')[0];
            Chapter = parts[0].Split(' ')[1];
            StartVerse = parts[1];
            EndVerse = parts[2];
        }
        else
        {
            var parts = reference.Split(':');
            Book = parts[0].Split(' ')[0];
            Chapter = parts[0].Split(' ')[1];
            StartVerse = parts[1];
            EndVerse = parts[1];
        }
    }

    public override string ToString()
    {
        return StartVerse == EndVerse 
            ? $"{Book} {Chapter}:{StartVerse}" 
            : $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
    }
}

class Word
{
    public string Text { get; private set; }
    public bool Hidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        Hidden = false;
    }

    public void Hide()
    {
        Hidden = true;
    }

    public override string ToString()
    {
        return Hidden ? "_____" : Text;
    }
}

class Scripture
{
    public ScriptureReference Reference { get; private set; }
    public string Text { get; private set; }
    private List<Word> Words { get; set; }

    public Scripture(string reference, string text)
    {
        Reference = new ScriptureReference(reference);
        Text = text;
        Words = new List<Word>();
        foreach (var word in Regex.Matches(text, @"\b\w+\b").Cast<Match>())
        {
            Words.Add(new Word(word.Value));
        }
    }

    public void HideRandomWords(int count = 3)
    {
        var wordsToHide = Words.Where(w => !w.Hidden).ToList();
        if (wordsToHide.Count == 0)
            return;

        var random = new Random();
        var selectedWords = wordsToHide.OrderBy(x => random.Next()).Take(count);
        foreach (var word in selectedWords)
        {
            word.Hide();
        }
    }

    public bool IsFullyHidden()
    {
        return Words.All(word => word.Hidden);
    }

    public override string ToString()
    {
        var displayedText = string.Join(" ", Words);
        return $"{Reference}\n{displayedText}";
    }
}

class Program
{
    private Scripture scripture;

    public Program()
    {
        scripture = GetNewScripture();
    }

    private Scripture GetNewScripture()
    {
        Console.Write("Enter the scripture reference (e.g., John 3:16 or Proverbs 3:5-6): ");
        string reference = Console.ReadLine().Trim();

        Console.Write("Enter the scripture text: ");
        string text = Console.ReadLine().Trim();

        return new Scripture(reference, text);
    }

    public void ClearConsole()
    {
        Console.Clear();
    }

    public void Run()
    {
        while (true)
        {
            ClearConsole();
            Console.WriteLine(scripture);
            if (scripture.IsFullyHidden())
            {
                Console.WriteLine("\nAll words are hidden. Press any key to end the program.");
                Console.ReadKey();
                break;
            }

            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit:");
            var userInput = Console.ReadLine().Trim().ToLower();
            if (userInput == "quit")
            {
                break;
            }

            scripture.HideRandomWords();
        }
    }

    static void Main(string[] args)
    {
        new Program().Run();
    }
}
