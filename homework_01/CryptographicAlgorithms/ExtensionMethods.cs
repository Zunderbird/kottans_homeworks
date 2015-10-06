using System;

namespace CryptographicAlgorithms
{
    public static class ExtensionMethods
    {
        public static char FirstSymbolAlphabet { get; set; }
        public static char LastSymbolAlphabet { get; set; }
        private const char SPACE = ' ';

        static ExtensionMethods()
        {
            FirstSymbolAlphabet = '!';
            LastSymbolAlphabet = '~';
            
        }

        public static string EnryptByCaesar(this string text, int key)
        {
            if (text == string.Empty) return string.Empty;
            if (text == null) throw new ArgumentNullException();

            var encrypted = string.Empty;

            foreach (var letter in text)
            {
                if (letter == SPACE)
                {
                    encrypted += SPACE;
                }
                else if (letter.IsCorrectSymbol())
                {
                    encrypted += Normalize((char) (letter + key));
                }
                else throw new ArgumentOutOfRangeException();
            }
            return encrypted;
        }

        public static bool IsCorrectSymbol(this char letter)
        {
            return (letter >= FirstSymbolAlphabet && letter <= LastSymbolAlphabet);
        }

        public static char Normalize(this char letter)
        {
            var lenght = LastSymbolAlphabet - FirstSymbolAlphabet + 1;

            while (letter < FirstSymbolAlphabet)
            {
                letter += (char) lenght;
            }
            while (letter > LastSymbolAlphabet)
            {
                letter -= (char) lenght;
            }
            return letter;
        }

    }
}
