using System;

class Program
{
    static void Main(string[] args)
    {
        // Create random number generator
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101); // number between 1 and 100

        int guess = -1; // initial value that does not match magicNumber
        int attempts = 0; // attempts counter

        Console.WriteLine("Welcome to Guess My Number!");
        Console.WriteLine("I have chosen a number between 1 and 100.");
        Console.WriteLine("Try to guess it!");

        // Loop until you guess
        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            string input = Console.ReadLine();
            guess = int.Parse(input);

            attempts++; // increase attempt counter

            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
                Console.WriteLine($"It took you {attempts} guesses.");
            }
        }
    }
}
