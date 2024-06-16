using System;

namespace MindfulnessApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose an activity by pressing the associated number on your keyboard and then pressing enter:");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Exit");

                string choice = Console.ReadLine();

                Activity activity = choice switch
                {
                    "1" => new BreathingActivity(),
                    "2" => new ReflectionActivity(),
                    "3" => new ListingActivity(),
                    "4" => null,
                    _ => null
                };

                if (activity == null)
                {
                    break;
                }

                activity.Start();
            }
        }
    }
}

/*
Additional features added for creativity:
- The program logs the number of items listed in the Listing Activity and displays it at the end.
- A spinner animation is used to enhance the user experience during pauses.
- Countdown timers are used to manage breathing cycles and reflection/question intervals.
- Added comments to improve code readability and maintainability.
*/
