using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    // Registra la meta simple: solo da puntos la primera vez
    public override int RecordEvent()
    {
        if (_isComplete)
        {
            Console.WriteLine("This goal was already completed. No points awarded.");
            return 0;
        }
        _isComplete = true;
        Console.WriteLine($"Congratulations! You completed '{_shortName}' and earned {_points} points!");
        return _points;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        // SimpleGoal:name,desc,points,isComplete
        return $"SimpleGoal:{_shortName},{_description},{_points},{_isComplete}";
    }

    public override string GetDetailsString()
    {
        string status = _isComplete ? "[X]" : "[ ]";
        return $"{status} {_shortName} ({_description})";
    }
}
