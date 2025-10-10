using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    // Cada vez que se registra, da puntos (nunca se "completa")
    public override int RecordEvent()
    {
        Console.WriteLine($"Progress recorded for '{_shortName}'. You earned {_points} points!");
        return _points;
    }

    public override bool IsComplete()
    {
        return false; // Nunca completa
    }

    public override string GetStringRepresentation()
    {
        // EternalGoal:name,desc,points
        return $"EternalGoal:{_shortName},{_description},{_points}";
    }

    public override string GetDetailsString()
    {
        return $"[∞] {_shortName} ({_description})";
    }
}
