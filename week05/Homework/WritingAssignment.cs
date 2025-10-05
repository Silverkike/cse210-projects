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

    public string GetStudentName()
    {
        // Método público para acceder al nombre del estudiante
        return GetSummary().Split(" - ")[0];
    }
}