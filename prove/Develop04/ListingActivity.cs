using System;
using System.Collections.Generic;

namespace MindfulnessApp
{
    class ListingActivity : Activity
    {
        private static readonly List<string> Prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        private static readonly Random Random = new Random();

        public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        {
        }

        protected override void RunActivity()
        {
            string prompt = Prompts[Random.Next(Prompts.Count)];
            Console.WriteLine(prompt);
            ShowSpinner(5);

            Console.WriteLine("Start listing items:");
            int start = Environment.TickCount;
            List<string> items = new List<string>();

            while ((Environment.TickCount - start) / 1000 < Duration)
            {
                string item = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(item))
                {
                    items.Add(item);
                }
            }

            Console.WriteLine($"You listed {items.Count} items.");
        }
    }
}
