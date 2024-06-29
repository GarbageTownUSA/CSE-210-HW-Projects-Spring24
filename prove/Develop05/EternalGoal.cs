namespace Develop05
{
    public class EternalGoal : Goal
    {
        public EternalGoal(string description) : base(description) { }

        public override int GetPoints() => 100;

        public override string ToFileString() => $"{nameof(EternalGoal)}|{Description}|{IsComplete}";
    }
}
