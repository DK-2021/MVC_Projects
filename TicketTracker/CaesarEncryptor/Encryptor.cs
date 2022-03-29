namespace CaesarEncryptor
{
    public class Encryptor
    {
        public string caesarCipher(string s, int k)
        {
            string solution = "";
            foreach (char c in s)
            {
                solution += Cipher(c, k);

            }
            return solution;
        }
        private char Cipher(char c, int k)
        {
            if (!char.IsLetter(c))
            {

                return c;
            }
            char d = char.IsUpper(c) ? 'A' : 'a';
            return (char)((((c + k) - d) % 26) + d);
        }
        private string Decypher(string s, int k)
        {
            return caesarCipher(s, 26 - k);
        }

    }
}