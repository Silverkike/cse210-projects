using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    // ----- Menú principal -----
    public void Start()
    {
        int choice = -1;
        while (choice != 7)
        {
            Console.WriteLine("\n=== Eternal Quest Menu ===");
            Console.WriteLine($"Points: {_score} | Rank: {GetPlayerRank()}");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goal Names");
            Console.WriteLine("3. List Goal Details");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Record Event");
            Console.WriteLine("7. Quit");
            Console.Write("Choose an option (1-7): ");

            string input = Console.ReadLine();
            if (!int.TryParse(input, out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    ListGoalNames();
                    break;
                case 3:
                    ListGoalDetails();
                    break;
                case 4:
                    SaveGoals();
                    break;
                case 5:
                    LoadGoals();
                    break;
                case 6:
                    RecordEvent();
                    break;
                case 7:
                    Console.WriteLine("Exiting Eternal Quest. Keep striving!");
                    break;
                default:
                    Console.WriteLine("Please choose a valid option.");
                    break;
            }
        }
    }

    // Muestra información del jugador
    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Points: {_score} | Rank: {GetPlayerRank()}");
    }

    // Lista solo nombres + status
    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals found.");
            return;
        }

        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    // Lista detalles (misma info, explícitamente)
    public void ListGoalDetails()
    {
        ListGoalNames();
    }

    // Crear nuevas metas por tipo
    public void CreateGoal()
    {
        Console.WriteLine("\nSelect goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choice (1-3): ");

        if (!int.TryParse(Console.ReadLine(), out int typeChoice) || typeChoice < 1 || typeChoice > 3)
        {
            Console.WriteLine("Invalid choice.");
            return;
        }

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Short Description: ");
        string description = Console.ReadLine();

        Console.Write("Points per event: ");
        if (!int.TryParse(Console.ReadLine(), out int points) || points < 0)
        {
            Console.WriteLine("Invalid points value.");
            return;
        }

        switch (typeChoice)
        {
            case 1:
                _goals.Add(new SimpleGoal(name, description, points));
                Console.WriteLine("Simple Goal created.");
                break;
            case 2:
                _goals.Add(new EternalGoal(name, description, points));
                Console.WriteLine("Eternal Goal created.");
                break;
            case 3:
                Console.Write("Target completions required: ");
                if (!int.TryParse(Console.ReadLine(), out int target) || target <= 0)
                {
                    Console.WriteLine("Invalid target.");
                    return;
                }

                Console.Write("Bonus points on completion: ");
                if (!int.TryParse(Console.ReadLine(), out int bonus) || bonus < 0)
                {
                    Console.WriteLine("Invalid bonus.");
                    return;
                }

                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                Console.WriteLine("Checklist Goal created.");
                break;
        }
    }

    // Registrar evento (elige meta, llama a RecordEvent y suma puntos)
    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record. Create one first.");
            return;
        }

        Console.WriteLine("\nWhich goal did you accomplish?");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
        Console.Write("Enter number: ");

        if (!int.TryParse(Console.ReadLine(), out int selection) || selection < 1 || selection > _goals.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        Goal chosen = _goals[selection - 1];

        int oldScore = _score;
        int earned = chosen.RecordEvent(); // POLIMORFISMO: cada clase decide qué devolver
        if (earned > 0)
        {
            _score += earned;
            CheckForLevelUp(oldScore, _score);
            Console.WriteLine($"You earned {earned} points. Total: {_score} points. Rank: {GetPlayerRank()}");
        }
        else
        {
            Console.WriteLine($"No points awarded. Total: {_score} points. Rank: {GetPlayerRank()}");
        }
    }

    // Guardar metas y puntaje en archivo
    public void SaveGoals()
    {
        Console.Write("Enter filename to save (e.g., savefile.txt): ");
        string filename = Console.ReadLine();
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine(_score);
                foreach (Goal g in _goals)
                {
                    writer.WriteLine(g.GetStringRepresentation());
                }
            }
            Console.WriteLine($"Saved to {filename}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    // Cargar desde archivo (asume formato guardado por GetStringRepresentation)
    public void LoadGoals()
    {
        Console.Write("Enter filename to load (e.g., savefile.txt): ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);
            if (lines.Length == 0)
            {
                Console.WriteLine("Empty file.");
                return;
            }

            _goals.Clear();
            _score = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split(':', 2);
                if (parts.Length < 2) continue;

                string type = parts[0];
                string data = parts[1];
                string[] fields = data.Split(',');

                if (type == "SimpleGoal")
                {
                    string name = fields[0];
                    string desc = fields[1];
                    int points = int.Parse(fields[2]);
                    bool isComplete = bool.Parse(fields[3]);

                    SimpleGoal sg = new SimpleGoal(name, desc, points);
                    if (isComplete)
                    {
                        sg.RecordEvent();
                        _score -= points;
                    }

                    _goals.Add(sg);
                }
                else if (type == "EternalGoal")
                {
                    string name = fields[0];
                    string desc = fields[1];
                    int points = int.Parse(fields[2]);

                    _goals.Add(new EternalGoal(name, desc, points));
                }
                else if (type == "ChecklistGoal")
                {
                    string name = fields[0];
                    string desc = fields[1];
                    int points = int.Parse(fields[2]);
                    int amountCompleted = int.Parse(fields[3]);
                    int target = int.Parse(fields[4]);
                    int bonus = int.Parse(fields[5]);

                    ChecklistGoal cg = new ChecklistGoal(name, desc, points, target, bonus);

                    // Usar reflection para setear _amountCompleted
                    var cgType = typeof(ChecklistGoal);
                    var field = cgType.GetField("_amountCompleted", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                    if (field != null)
                    {
                        field.SetValue(cg, amountCompleted);
                    }

                    _goals.Add(cg);
                }
            }

            Console.WriteLine($"Loaded {_goals.Count} goals from {filename}. Current points set to {_score}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
        }
    }

    // ---------------- Level / Rank system (Opción A: creatividad)
    private string GetPlayerRank()
    {
        if (_score >= 10000)
            return "Eternal Legend ";
        else if (_score >= 5000)
            return "Master ";
        else if (_score >= 2500)
            return "Hero ";
        else if (_score >= 1000)
            return "Adventurer ";
        else
            return "Novice ";
    }

    private void CheckForLevelUp(int oldScore, int newScore)
    {
        string oldRank = GetRankFromScore(oldScore);
        string newRank = GetRankFromScore(newScore);

        if (oldRank != newRank)
        {
            Console.WriteLine($"\n🎉 LEVEL UP! You have advanced from {oldRank} to {newRank}!\n");
        }
    }

    private string GetRankFromScore(int score)
    {
        if (score >= 10000)
            return "Eternal Legend";
        else if (score >= 5000)
            return "Master";
        else if (score >= 2500)
            return "Hero";
        else if (score >= 1000)
            return "Adventurer";
        else
            return "Novice";
    }
}
