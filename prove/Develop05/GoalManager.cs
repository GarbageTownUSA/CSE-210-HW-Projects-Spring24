using System;
using System.Collections.Generic;
using System.IO;

namespace Develop05
{
    public class GoalManager
    {
        private List<Goal> goals;
        private int userScore;
        private int userXP;
        private int userLevel;

        public GoalManager()
        {
            goals = new List<Goal>();
            userScore = 0;
            userXP = 0;
            userLevel = 1;
        }

        public void CreateGoal(Goal goal)
        {
            goals.Add(goal);
        }

        public void RecordEvent(int goalIndex)
        {
            if (goalIndex >= 0 && goalIndex < goals.Count)
            {
                Goal goal = goals[goalIndex];
                if (goal is ChecklistGoal checklistGoal)
                {
                    checklistGoal.RecordEvent();
                }
                else
                {
                    goal.MarkComplete();
                }

                userScore += goal.GetPoints();
                userXP += goal.GetPoints();
                UpdateLevel();
            }
            else
            {
                Console.WriteLine("Invalid goal number.");
                Console.WriteLine();
            }
        }

        public void DisplayGoals()
        {
            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i]}");
            }
            Console.WriteLine();
        }

        public void DeleteGoal(int goalIndex)
        {
            if (goalIndex >= 0 && goalIndex < goals.Count)
            {
                goals.RemoveAt(goalIndex);
                Console.WriteLine("Goal deleted successfully.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Invalid goal number.");
                Console.WriteLine();
            }
        }

        public void SaveData(string filename)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    writer.WriteLine($"UserScore:{userScore}");
                    writer.WriteLine($"UserXP:{userXP}");
                    writer.WriteLine($"UserLevel:{userLevel}");

                    foreach (var goal in goals)
                    {
                        writer.WriteLine(goal.ToFileString());
                    }
                }
                Console.WriteLine("Data saved successfully.");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving data: {ex.Message}");
                Console.WriteLine();
            }
        }

        public void LoadData(string filename)
        {
            try
            {
                if (File.Exists(filename))
                {
                    using (StreamReader reader = new StreamReader(filename))
                    {
                        goals.Clear(); // Clear existing goals before loading

                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.StartsWith("UserScore:"))
                            {
                                userScore = int.Parse(line.Substring("UserScore:".Length));
                            }
                            else if (line.StartsWith("UserXP:"))
                            {
                                userXP = int.Parse(line.Substring("UserXP:".Length));
                            }
                            else if (line.StartsWith("UserLevel:"))
                            {
                                userLevel = int.Parse(line.Substring("UserLevel:".Length));
                            }
                            else
                            {
                                Goal goal = Goal.FromFileString(line);
                                if (goal != null)
                                {
                                    goals.Add(goal);
                                }
                            }
                        }
                    }
                    Console.WriteLine("Data loaded successfully.");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("File not found.");
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading data: {ex.Message}");
                Console.WriteLine();
            }
        }

        public int GetUserScore()
        {
            return userScore;
        }

        public int GetUserXP()
        {
            return userXP;
        }

        public int GetUserLevel()
        {
            return userLevel;
        }

        private void UpdateLevel()
        {
            int newLevel = (userXP / 1000) + 1;
            if (newLevel > userLevel)
            {
                userLevel = newLevel;
                Console.WriteLine($"Congratulations! You've reached level {userLevel}!");
                Console.WriteLine();
            }
        }
    }
}
