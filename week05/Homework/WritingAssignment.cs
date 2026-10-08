using System;

public class WritingAssignment : Assignment
{
    private string _title;

    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }

    public string GetWritingInformation()
    {
        return $"{_title} by {GetStudentName()}";
    }

    private string GetStudentName()
    {
        // Assuming the base class has a method to get the student's name
        return base.GetSummary().Split(" - ")[0];
    }
}