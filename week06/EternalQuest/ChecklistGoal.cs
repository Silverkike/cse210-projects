using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    // Incrementa cantidades; si alcanza target, otorga puntos + bonus
    public override int RecordEvent()
    {
        if (IsComplete())
        {
            Console.WriteLine($"This checklist goal '{_shortName}' is already complete. No more progress needed.");
            return 0;
        }

        _amountCompleted++;
        int earned = _points;

        if (IsComplete())
        {
            // On completion, return points + bonus
            earned += _bonus;
            Console.WriteLine($"Congratulations! You completed '{_shortName}' and earned {_points} points + {_bonus} bonus points!");
        }
        else
        {
            Console.WriteLine($"Progress recorded for '{_shortName}': {_amountCompleted}/{_target}. You earned {_points} points.");
        }

        return earned;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {_shortName} ({_description}) -- Completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        // ChecklistGoal:name,desc,points,amountCompleted,target,bonus
        return $"ChecklistGoal:{_shortName},{_description},{_points},{_amountCompleted},{_target},{_bonus}";
    }
}
