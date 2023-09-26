using System;

class VigenereCipher
{
    static void getKeyMatrix(string key, int[,] keyMatrix)
    {
        int k = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                keyMatrix[i, j] = (key[k] - 'A') % 26;
                k++;
            }
        }
    }

    static void encrypt(int[,] cipherMatrix, int[,] keyMatrix, int[,] messageVector)
    {
        int x, i, j;
        for (i = 0; i < 3; i++)
        {
            for (j = 0; j < 1; j++)
            {
                cipherMatrix[i, j] = 0;

                for (x = 0; x < 3; x++)
                {
                    cipherMatrix[i, j] += keyMatrix[i, x] * messageVector[x, j];
                }

                cipherMatrix[i, j] = cipherMatrix[i, j] % 26;
            }
        }
    }

    static void HillCipher(string message, string key)
    {
        int[,] keyMatrix = new int[3, 3];
        getKeyMatrix(key, keyMatrix);

        int[,] messageVector = new int[3, 1];

        for (int i = 0; i < message.Length; i++)
        {
            messageVector[i, 0] = (message[i] - 'A') % 26;
        }

        int[,] cipherMatrix = new int[3, 1];

        encrypt(cipherMatrix, keyMatrix, messageVector);

        string cipherText = "";

        for (int i = 0; i < message.Length; i++)
        {
            cipherText += (char)(cipherMatrix[i, 0] + 'A');
        }

        Console.WriteLine("Ciphertext: " + cipherText);
    }

    static string generateKey(string str, string key)
    {
        int x = str.Length;
        string generatedKey = "";

        for (int i = 0; ; i++)
        {
            if (x == i)
                i = 0;
            if (key.Length == str.Length)
                break;
            generatedKey += key[i];
        }
        return generatedKey;
    }

    static string cipherText(string str, string key)
    {
        string cipherText = "";

        for (int i = 0; i < str.Length; i++)
        {
            int x = (str[i] + key[i]) % 26;
            x += 'A';
            cipherText += (char)(x);
        }
        return cipherText;
    }

    static string originalText(string cipher_text, string key)
    {
        char[] orig_text = new char[cipher_text.Length];

        for (int i = 0; i < cipher_text.Length && i < key.Length; i++)
        {
            int x = (cipher_text[i] - key[i] + 26) % 26;
            x += 'A';
            orig_text[i] = (char)(x);
        }
        return new string(orig_text);
    }

    public static void Main(string[] args)
    {
        string str = "ITSOKAY";
        string keyword = "AYUSH";

        string key = generateKey(str, keyword);
        string cipher_text = cipherText(str, key);

        Console.WriteLine("Ciphertext: " + cipher_text);

        string original_text = originalText(cipher_text, key);
        Console.WriteLine("Original/Decrypted Text: " + original_text);
    }
}
