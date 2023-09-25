// C# code to implement Vigenere Cipher
using System;
	
class ALEX
{
// This function generates the key in
// a cyclic manner until it's length isi'nt
// equal to the length of original text
// Following function generates the
// key matrix for the key string
static void getKeyMatrix(String key,
                         int [,]keyMatrix)
{
    int k = 0;
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            keyMatrix[i, j] = (key[k]) % 65;
            k++;
        }
    }
}
 
// Following function encrypts the message
static void encrypt(int [,]cipherMatrix,
                    int [,]keyMatrix,
                    int [,]messageVector)
{
    int x, i, j;
    for (i = 0; i < 3; i++)
    {
        for (j = 0; j < 1; j++)
        {
            cipherMatrix[i, j] = 0;
         
            for (x = 0; x < 3; x++)
            {
                cipherMatrix[i, j] += keyMatrix[i, x] *
                                      messageVector[x, j];
            }
         
            cipherMatrix[i, j] = cipherMatrix[i, j] % 26;
        }
    }
}
 
// Function to implement Hill Cipher
static void HillCipher(String message, String key)
{
     
    // Get key matrix from the key string
    int [,]keyMatrix = new int[3, 3];
    getKeyMatrix(key, keyMatrix);
 
    int [,]messageVector = new int[3, 1];
 
    // Generate vector for the message
    for (int i = 0; i < 3; i++)
        messageVector[i, 0] = (message[i]) % 65;
 
    int [,]cipherMatrix = new int[3, 1];
 
    // Following function generates
    // the encrypted vector
    encrypt(cipherMatrix, keyMatrix, messageVector);
 
    String CipherText = "";
 
    // Generate the encrypted text from
    // the encrypted vector
    for (int i = 0; i < 3; i++)
        CipherText += (char)(cipherMatrix[i, 0] + 65);
 
    // Finally print the ciphertext
    Console.Write("Ciphertext: " + CipherText);
}

static String generateKey(String str, String key)
{
	int x = str.Length;

	for (int i = 0; ; i++)
	{
		if (x == i)
			i = 0;
		if (key.Length == str.Length)
			break;
		key+=(key[i]);
	}
	return key;
}

// This function returns the encrypted text
// generated with the help of the key
static String cipherText(String str, String key)
{
	String cipher_text="";

	for (int i = 0; i < str.Length; i++)
	{
		// converting in range 0-25
		int x = (str[i] + key[i]) %26;

		// convert into alphabets(ASCII)
		x += 'A';

		cipher_text+=(char)(x);
	}
	return cipher_text;
}

// This function decrypts the encrypted text
// and returns the original text
static String originalText(String cipher_text, String key)
{
	String orig_text="";

	for (int i = 0 ; i < cipher_text.Length &&
							i < key.Length; i++)
	{
		// converting in range 0-25
		int x = (cipher_text[i] -
					key[i] + 26) %26;

		// convert into alphabets(ASCII)
		x += 'A';
		orig_text+=(char)(x);
	}
	return orig_text;
}

// Driver code
public static void Main(String[] args)
{
	String str = "ITS OKAY";
	String keyword = "AYUSH";

	String key = generateKey(str, keyword);
	String cipher_text = cipherText(str, key);

	Console.WriteLine("Ciphertext : "
		+ cipher_text + "\n");

	Console.WriteLine("Original/Decrypted Text : "
		+ originalText(cipher_text, key));
	}
    HillCipher(message, key);
}

/* This code contributed by PrinciRaj1992 */
