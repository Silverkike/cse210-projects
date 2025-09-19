// Enhancement: Instead of working with a single scripture, this program now uses a library of scriptures. Each time the program runs, it randomly selects one scripture from the library to present to the user.

using System;
using System.Collections.Generic;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creamos una librería de escrituras
            List<Scripture> library = new List<Scripture>();

            // Agregamos escrituras 
            library.Add(new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world that he gave his one and only Son, " +
                "that whoever believes in him shall not perish but have eternal life."
            ));

            library.Add(new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding. " +
                "In all thy ways acknowledge him, and he shall direct thy paths."
            ));

            library.Add(new Scripture(
                new Reference("Mosiah", 2, 17),
                "When ye are in the service of your fellow beings ye are only in the service of your God."
            ));

            library.Add(new Scripture(
                new Reference("2 Nephi", 2, 25),
                "Adam fell that men might be; and men are, that they might have joy."
            ));

            // Seleccionamos una escritura al azar
            Random random = new Random();
            int index = random.Next(library.Count);
            Scripture scripture = library[index];

            // Bucle principal
            while (true)
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nPresiona ENTER para ocultar palabras o escribe 'quit' para salir.");

                string input = Console.ReadLine();

                if (input.ToLower() == "quit")
                {
                    break;
                }

                // Ocultamos 3 palabras por cada enter
                scripture.HideRandomWords(3);

                // Si ya no quedan palabras, salimos
                if (scripture.IsCompletelyHidden())
                {
                    Console.Clear();
                    Console.WriteLine(scripture.GetDisplayText());
                    Console.WriteLine("\n¡Felicidades! Has memorizado toda la escritura. 🙌📖");
                    break;
                }
            }
        }
    }
}
