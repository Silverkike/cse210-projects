using System;

public abstract class Goal
{
    // Encapsulación: campos protegidos con prefijo "_" (accesibles por clases derivadas)
    protected string _shortName;
    protected string _description;
    protected int _points;

    // Constructor base
    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    // Registra el evento para la meta y devuelve los puntos ganados (polimorfismo)
    public abstract int RecordEvent();

    // Indica si la meta está completa
    public abstract bool IsComplete();

    // Representación para mostrar en listas (por defecto)
    public virtual string GetDetailsString()
    {
        return $"{_shortName} ({_description})";
    }

    // Cadena que será guardada en archivo para reconstruir el objeto
    public abstract string GetStringRepresentation();
}
