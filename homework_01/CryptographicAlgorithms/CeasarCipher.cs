namespace CryptographicAlgorithms
{
    public class CeasarCipher
    {
        public int Offset { get; }

        public CeasarCipher(int offset)
        {
            Offset = offset;
        }

        public string Encrypt(string text)
        {
            return text.EnryptByCaesar(Offset);
        }

        public string Decrypt(string text)
        {
            return text.EnryptByCaesar(-Offset);
        }
    }
}
