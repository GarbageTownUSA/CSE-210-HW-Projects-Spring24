using System;
using System.Threading;

namespace MindfulnessApp
{
    abstract class Activity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Duration { get; private set; }

        public Activity(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void Start()
        {
            Console.Clear();
            Console.WriteLine($"Starting {Name} Activity");
            Console.WriteLine($"{Description}");
            Console.Write("Enter duration in seconds: ");
            Duration = int.Parse(Console.ReadLine());
            Console.WriteLine("Prepare to begin...");
            ShowSpinner(3);

            RunActivity();

            Console.WriteLine("Good job!");
            Console.WriteLine($"You have completed the {Name} Activity for {Duration} seconds.");
            ShowSpinner(3);
        }

        protected abstract void RunActivity();

        protected void ShowSpinner(int seconds)
        {
            for (int i = 0; i < seconds; i++)
            {
                Console.Write("/");
                Thread.Sleep(250);
                Console.Write("\b-");
                Thread.Sleep(250);
                Console.Write("\b\\");
                Thread.Sleep(250);
                Console.Write("\b|");
                Thread.Sleep(250);
                Console.Write("\b");
            }
        }

        protected void ShowCountdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }
    }
}
