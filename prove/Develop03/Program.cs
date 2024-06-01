using System;

namespace ScriptureMemorization
{
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
}
