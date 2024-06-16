using System;
using System.Collections.Generic;

namespace MindfulnessApp
{
    class ReflectionActivity : Activity
    {
        private static readonly List<string> Prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private static readonly List<string> Questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        private static readonly Random Random = new Random();

        public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
        {
        }

        protected override void RunActivity()
        {
            string prompt = Prompts[Random.Next(Prompts.Count)];
            Console.WriteLine(prompt);
            ShowSpinner(5);

            int elapsed = 0;
            while (elapsed < Duration)
            {
                string question = Questions[Random.Next(Questions.Count)];
                Console.WriteLine(question);
                ShowSpinner(5);
                elapsed += 5;
            }
        }
    }
}
