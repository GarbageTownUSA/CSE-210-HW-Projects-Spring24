namespace Develop05
{
    public class ChecklistGoal : Goal
    {
        public int TargetCount { get; set; }
        public int CurrentCount { get; set; }
        public int BonusPoints { get; set; }

        public ChecklistGoal(string description, int targetCount) : base(description)
        {
            TargetCount = targetCount;
            CurrentCount = 0;
            BonusPoints = 500;
        }

        public override int GetPoints()
        {
            if (CurrentCount < TargetCount)
            {
                return 50;
            }
            return 50 + BonusPoints;
        }

        public void RecordEvent()
        {
            if (CurrentCount < TargetCount)
            {
                CurrentCount++;
                if (CurrentCount >= TargetCount)
                {
                    MarkComplete();
                }
            }
        }

        public override string ToString() =>
            base.ToString() + $" (Completed {CurrentCount}/{TargetCount} times)";

        public override string ToFileString() =>
            $"{nameof(ChecklistGoal)}|{Description}|{IsComplete}|{TargetCount}|{CurrentCount}";
    }
}
