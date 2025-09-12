using System;

class Program
{
    static void Main(string[] args)
    {

        Random randomGenerator = new Random();

        double number1 = randomGenerator.NextDouble();       // entre 0.0 y 1.0
        double number2 = randomGenerator.NextDouble() * 10;  // entre 0.0 y 10.0
        double number3 = 5 + randomGenerator.NextDouble() * (15 - 5); // entre 5.0 y 15.0

        Console.WriteLine(number1);
        Console.WriteLine(number2);
        Console.WriteLine(number3);

    }
}