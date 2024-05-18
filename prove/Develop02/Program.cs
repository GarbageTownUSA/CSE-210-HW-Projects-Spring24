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



