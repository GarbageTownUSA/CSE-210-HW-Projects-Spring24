using System;

namespace MindfulnessApp
{
    class BreathingActivity : Activity
    {
        public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        {
        }

        protected override void RunActivity()
        {
            int elapsed = 0;
            while (elapsed < Duration)
            {
                Console.WriteLine("Breathe in...");
                ShowCountdown(3);
                elapsed += 3;
                Console.WriteLine("Breathe out...");
                ShowCountdown(3);
                elapsed += 3;
            }
        }
    }
}
