using System;
using System.Collections.Generic;
using System.Linq; // Para usar funciones como Min() y Sort()

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // 1. Pedir números hasta que el usuario escriba 0
        int userNumber;
        do
        {
            Console.Write("Enter number: ");
            userNumber = int.Parse(Console.ReadLine());

            if (userNumber != 0) // No agregar el 0 a la lista
            {
                numbers.Add(userNumber);
            }

        } while (userNumber != 0);

        // --- Core Requirements ---

        // 2. Calcular la suma
        int sum = numbers.Sum();

        // 3. Calcular el promedio
        double average = numbers.Average();

        // 4. Encontrar el número más grande
        int max = numbers.Max();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");

        // --- Stretch Challenges ---

        // 5. Encontrar el número positivo más pequeño
        // (es decir, el positivo más cercano a cero)
        List<int> positiveNumbers = numbers.Where(n => n > 0).ToList();
        if (positiveNumbers.Count > 0)
        {
            int smallestPositive = positiveNumbers.Min();
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }

        // 6. Ordenar la lista y mostrarla
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}
