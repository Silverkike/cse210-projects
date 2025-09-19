// Scripture.cs
using System;
using System.Collections.Generic;

namespace ScriptureMemorizer
{
    // Representa una escritura completa (referencia + palabras)
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;
        private Random _random;

        // Constructor: recibe la referencia y el texto de la escritura
        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = new List<Word>();
            _random = new Random();

            // Divide el texto en palabras y crea objetos Word
            string[] parts = text.Split(' ');
            foreach (string part in parts)
            {
                _words.Add(new Word(part));
            }
        }

        // Devuelve el texto completo (referencia + palabras, ocultas o no)
        public string GetDisplayText()
        {
            List<string> displayWords = new List<string>();
            foreach (Word word in _words)
            {
                displayWords.Add(word.GetDisplayText());
            }

            string scriptureText = string.Join(" ", displayWords);
            return $"{_reference.ToString()} - {scriptureText}";
        }

        // Oculta un número aleatorio de palabras
        public void HideRandomWords(int numberToHide)
        {
            int hiddenCount = 0;
            while (hiddenCount < numberToHide && !IsCompletelyHidden())
            {
                int index = _random.Next(_words.Count);
                if (!_words[index].IsHidden())
                {
                    _words[index].Hide();
                    hiddenCount++;
                }
            }
        }

        // Verifica si toda la escritura está oculta
        public bool IsCompletelyHidden()
        {
            foreach (Word word in _words)
            {
                if (!word.IsHidden())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
