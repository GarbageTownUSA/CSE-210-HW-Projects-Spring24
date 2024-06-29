using System;

namespace Develop05
{
    public abstract class Goal
    {
        public string Description { get; set; }
        public bool IsComplete { get; set; }

        public Goal(string description)
        {
            Description = description;
            IsComplete = false;
        }

        protected Goal()
        {
            Description = string.Empty;
            IsComplete = false;
        }

        public abstract int GetPoints();
        public virtual void MarkComplete() => IsComplete = true;

        public override string ToString() => $"[{(IsComplete ? "X" : " ")}] {Description}";

        public virtual string ToFileString() => $"{GetType().Name}|{Description}|{IsComplete}";

        public static Goal FromFileString(string data)
        {
            try
            {
                string[] parts = data.Split('|');
                string typeName = parts[0];
                string description = parts[1];
                bool isComplete = bool.Parse(parts[2]);

                Goal goal;

                switch (typeName)
                {
                    case nameof(SimpleGoal):
                        goal = new SimpleGoal(description);
                        break;
                    case nameof(EternalGoal):
                        goal = new EternalGoal(description);
                        break;
                    case nameof(ChecklistGoal):
                        int targetCount = int.Parse(parts[3]);
                        int currentCount = int.Parse(parts[4]);
                        goal = new ChecklistGoal(description, targetCount) { IsComplete = isComplete };
                        ((ChecklistGoal)goal).CurrentCount = currentCount;
                        break;
                    default:
                        return null;
                }

                if (isComplete)
                {
                    goal.MarkComplete();
                }

                return goal;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
