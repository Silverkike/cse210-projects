using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string userName = PromptUserName();
        int favoriteNumber = PromptUserNumber();
        int squaredNumber = SquareNumber(favoriteNumber);

        DisplayResult(userName, squaredNumber);
    }

    // 1. DisplayWelcome - muestra el mensaje de bienvenida
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    // 2. PromptUserName - pide el nombre del usuario y lo devuelve
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    // 3. PromptUserNumber - pide el número favorito y lo devuelve como entero
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    // 4. SquareNumber - recibe un número entero y devuelve su cuadrado
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // 5. DisplayResult - muestra el resultado con nombre y número al cuadrado
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }
}
