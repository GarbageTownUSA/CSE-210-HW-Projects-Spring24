namespace Assign
{
    4public class WritingAssignment : Assignment
{
    private string _title;

    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        // Here we set any variables specific to the WritingAssignment class
        _title = title;
    }

    public string GetWritingInformation()
    {
        // Notice that we are calling the getter here because _studentName is private in the base class
        string studentName = GetStudentName();

        return $"{_title} by {studentName}";
    }
}
}