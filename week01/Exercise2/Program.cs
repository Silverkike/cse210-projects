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

        // Determine the letter
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

        // Determine the sign (only if not F)
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

        // Special cases:
        // There is no A+
        if (letter == "A" && sign == "+")
        {
            sign = "";
        }

        // There is no F+ or F-
        if (letter == "F")
        {
            sign = "";
        }

        // Display the rating with sign
        Console.WriteLine($"Letter grade: {letter}{sign}");

        // Approved or failed message
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
