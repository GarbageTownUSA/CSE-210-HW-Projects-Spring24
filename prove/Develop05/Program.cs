using System;

namespace Develop05
{
    class Program
    {
        static void Main(string[] args)
        {
            GoalManager goalManager = new GoalManager();

            // Load data from file
            goalManager.LoadData("goals.txt");

            Console.WriteLine("Welcome to Eternal Quest!");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Create a new goal");
                Console.WriteLine("2. Record an event (complete a goal)");
                Console.WriteLine("3. Display goals");
                Console.WriteLine("4. Delete a goal");
                Console.WriteLine("5. Show user score and level");
                Console.WriteLine("6. Save goals and exit");
                Console.WriteLine();

                Console.Write("Enter your choice: ");
                string input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        CreateGoal(goalManager);
                        break;
                    case "2":
                        RecordEvent(goalManager);
                        break;
                    case "3":
                        goalManager.DisplayGoals();
                        break;
                    case "4":
                        DeleteGoal(goalManager);
                        break;
                    case "5":
                        ShowScoreAndLevel(goalManager);
                        break;
                    case "6":
                        goalManager.SaveData("goals.txt");
                        Console.WriteLine("Goals saved. Exiting program.");
                        return;
                    default:
                        Console.WriteLine("Invalid input. Please enter a number from 1 to 6.");
                        break;
                }
            }
        }

        static void CreateGoal(GoalManager goalManager)
        {
            Console.WriteLine("Enter the description of the goal:");
            string description = Console.ReadLine();
            Console.WriteLine("Select the type of goal:");
            Console.WriteLine("1. Simple goal");
            Console.WriteLine("2. Eternal goal");
            Console.WriteLine("3. Checklist goal");

            Console.Write("Enter your choice: ");
            string input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1":
                    goalManager.CreateGoal(new SimpleGoal(description));
                    Console.WriteLine("Simple goal created.");
                    break;
                case "2":
                    goalManager.CreateGoal(new EternalGoal(description));
                    Console.WriteLine("Eternal goal created.");
                    break;
                case "3":
                    Console.WriteLine("Enter the target count for checklist goal:");
                    int targetCount = int.Parse(Console.ReadLine());
                    goalManager.CreateGoal(new ChecklistGoal(description, targetCount));
                    Console.WriteLine("Checklist goal created.");
                    break;
                default:
                    Console.WriteLine("Invalid input. Goal creation canceled.");
                    break;
            }
            Console.WriteLine();
        }

        static void RecordEvent(GoalManager goalManager)
        {
            goalManager.DisplayGoals();
            Console.Write("Enter the number of the goal you completed: ");
            string input = Console.ReadLine();
            Console.WriteLine();

            if (int.TryParse(input, out int goalIndex))
            {
                goalManager.RecordEvent(goalIndex - 1); // Adjust index to zero-based
            }
            else
            {
                Console.WriteLine("Invalid input. Could not record event.");
                Console.WriteLine();
            }
        }

        static void DeleteGoal(GoalManager goalManager)
        {
            goalManager.DisplayGoals();
            Console.Write("Enter the number of the goal you want to delete: ");
            string input = Console.ReadLine();
            Console.WriteLine();

            if (int.TryParse(input, out int goalIndex))
            {
                goalManager.DeleteGoal(goalIndex - 1); // Adjust index to zero-based
            }
            else
            {
                Console.WriteLine("Invalid input. Could not delete goal.");
                Console.WriteLine();
            }
        }

        static void ShowScoreAndLevel(GoalManager goalManager)
        {
            int score = goalManager.GetUserScore();
            int level = goalManager.GetUserLevel();

            Console.WriteLine($"Current Score: {score}");
            Console.WriteLine($"Current Level: {level}");
            Console.WriteLine();
        }
    }
}


/*
 * Exceeding Requirements:
 * - Implemented levels and experience points (XP) system:
 *   Users can earn XP for completing goals, allowing them to level up.
 * - Set the amount of points automatically based on the type of goal completed.
 * - Added exception handling to manage invalid user inputs gracefully.
 * - Added a feature to delete goals.
 */
