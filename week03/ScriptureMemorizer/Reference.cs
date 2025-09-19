// Reference.cs
using System;

namespace ScriptureMemorizer
{
    // Clase que representa la referencia de la escritura (ej. "John 3:16" o "Proverbs 3:5-6")
    public class Reference
    {
        private string _book;
        private int _chapter;
        private int _startVerse;
        private int _endVerse;

        // Constructor para un solo versículo (ej. John 3:16)
        public Reference(string book, int chapter, int verse)
        {
            _book = book;
            _chapter = chapter;
            _startVerse = verse;
            _endVerse = verse;
        }

        // Constructor para un rango de versículos (ej. Proverbs 3:5-6)
        public Reference(string book, int chapter, int startVerse, int endVerse)
        {
            _book = book;
            _chapter = chapter;
            _startVerse = startVerse;
            _endVerse = endVerse;
        }

        // Devuelve la referencia formateada apropiadamente
        public override string ToString()
        {
            if (_startVerse == _endVerse)
            {
                return $"{_book} {_chapter}:{_startVerse}";
            }
            else
            {
                return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
            }
        }
    }
}
