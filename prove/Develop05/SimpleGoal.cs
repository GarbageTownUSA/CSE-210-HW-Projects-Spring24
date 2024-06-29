namespace Develop05
{
    public class SimpleGoal : Goal
    {
        public SimpleGoal(string description) : base(description) { }

        public override int GetPoints() => 1000;

        public override string ToFileString() => $"{nameof(SimpleGoal)}|{Description}|{IsComplete}";
    }
}
