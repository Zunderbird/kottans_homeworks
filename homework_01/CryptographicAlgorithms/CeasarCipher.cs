using System;

namespace CryptographicAlgorithms
{
    public class CeasarCipher
    {
        public int Offset { get; }

        private const char SPACE = ' ';
        public static char FirstSymbolAlphabet { get; set; } = '!';
        public static char LastSymbolAlphabet { get; set; } = '~';
        private static int SymbolsCount => LastSymbolAlphabet - FirstSymbolAlphabet + 1;

        public CeasarCipher(int offset)
        {
            Offset = offset;
        }

        public string Encrypt(string text)
        {
            return EnryptByCaesar(text, Offset % SymbolsCount);
        }

        public string Decrypt(string text)
        {
            return EnryptByCaesar(text, SymbolsCount - Offset % SymbolsCount);
        }

        public static string EnryptByCaesar(string text, int key)
        {
            if (text == string.Empty) return string.Empty;
            if (text == null) throw new ArgumentNullException();

            var encrypted = new char[text.Length];
            var count = 0;

            foreach (var letter in text)
            {
                if (!IsCorrectSymbol(letter)) throw new ArgumentOutOfRangeException();
                encrypted[count++] = (letter == SPACE) ? SPACE : Normalize((char)(letter + key));
            }
            return new string(encrypted);
        }

        private static bool IsCorrectSymbol(char letter)
        {
            return (letter >= FirstSymbolAlphabet && letter <= LastSymbolAlphabet || letter == SPACE);
        }

        public static char Normalize(char letter)
        {
            return (char)((letter - FirstSymbolAlphabet) % SymbolsCount + FirstSymbolAlphabet);
        }
    }
}
