using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is the student grade percentage? ");
        string percentage = Console.ReadLine();
        int grade = int.Parse(percentage);

        string letter = "";
        string sign = "";

        // Determinar la letra
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determinar el signo (solo si no es F)
        if (letter != "F")
        {
            int lastDigit = grade % 10;

            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }

        // Casos especiales:
        // No existe A+
        if (letter == "A" && sign == "+")
        {
            sign = "";
        }

        // No existe F+ ni F-
        if (letter == "F")
        {
            sign = "";
        }

        // Mostrar la calificación con signo
        Console.WriteLine($"Letter grade: {letter}{sign}");

        // Mensaje de aprobado o no
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations, you passed the course!");
        }
        else
        {
            Console.WriteLine("We encourage you to strive more next time!");
        }
    }
}
