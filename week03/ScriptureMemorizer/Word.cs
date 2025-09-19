// Word.cs
using System;

namespace ScriptureMemorizer
{
    // Representa una sola palabra en la escritura
    public class Word
    {
        private string _text;
        private bool _isHidden;

        // Constructor que recibe la palabra
        public Word(string text)
        {
            _text = text;
            _isHidden = false;
        }

        // Oculta la palabra (marca como hidden)
        public void Hide()
        {
            _isHidden = true;
        }

        // Verifica si la palabra está oculta
        public bool IsHidden()
        {
            return _isHidden;
        }

        // Devuelve la palabra: si está oculta, muestra guiones bajos
        public string GetDisplayText()
        {
            if (_isHidden)
            {
                return new string('_', _text.Length);
            }
            else
            {
                return _text;
            }
        }
    }
}
