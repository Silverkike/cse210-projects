using System;
using System.Collections.Generic;  // Necesario para usar List

public class Resume
{
    // Variables miembro
    public string _name;           // Nombre de la persona
    public List<Job> _jobs = new List<Job>();  // Lista de trabajos, inicializada vacía

    // Método para mostrar la información del resume
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        foreach (Job job in _jobs)
        {
            job.Display();  // Llamamos al método Display de cada trabajo
        }
    }
}
