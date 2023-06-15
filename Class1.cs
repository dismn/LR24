using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace LR24
{
    public class CRABCipher
    {
        public static string Encrypt(string plaintext, int shift)
        {
            string encryptedText = "";

            foreach (char c in plaintext)
            {
                if (char.IsLetter(c))
                {
                    char encryptedChar = (char)(c + shift);

                    if (char.IsUpper(c))
                    {
                        if (encryptedChar > 'Z')
                            encryptedChar = (char)(encryptedChar - 26);
                        else if (encryptedChar < 'A')
                            encryptedChar = (char)(encryptedChar + 26);
                    }
                    else
                    {
                        if (encryptedChar > 'z')
                            encryptedChar = (char)(encryptedChar - 26);
                        else if (encryptedChar < 'a')
                            encryptedChar = (char)(encryptedChar + 26);
                    }

                    encryptedText += encryptedChar;
                }
                else
                {
                    encryptedText += c;
                }
            }

            return encryptedText;
        }

        public static string Decrypt(string ciphertext, int shift)
        {
            return Encrypt(ciphertext, -shift);
        }
    }

    public class HillCipher
    {
        private static int[,] GenerateKeyMatrix(string key)
        {
            int keySize = (int)Math.Sqrt(key.Length);
            int[,] keyMatrix = new int[keySize, keySize];

            int currentIndex = 0;
            for (int i = 0; i < keySize; i++)
            {
                for (int j = 0; j < keySize; j++)
                {
                    keyMatrix[i, j] = key[currentIndex] - 'A';
                    currentIndex++;
                }
            }

            return keyMatrix;
        }

        private static string ApplyKeyMatrix(int[,] keyMatrix, string plaintext)
        {
            int keySize = (int)Math.Sqrt(keyMatrix.Length);
            int[] plaintextVector = new int[keySize];
            int[] encryptedVector = new int[keySize];
            StringBuilder encryptedText = new StringBuilder();

            for (int i = 0; i < plaintext.Length; i += keySize)
            {
                for (int j = 0; j < keySize; j++)
                {
                    plaintextVector[j] = plaintext[i + j] - 'A';
                }

                for (int j = 0; j < keySize; j++)
                {
                    encryptedVector[j] = 0;

                    for (int k = 0; k < keySize; k++)
                    {
                        encryptedVector[j] += keyMatrix[j, k] * plaintextVector[k];
                    }

                    encryptedVector[j] %= 26;
                    encryptedText.Append((char)(encryptedVector[j] + 'A'));
                }
            }

            return encryptedText.ToString();
        }

        private static int GetMatrixDeterminant(int[,] matrix)
        {
            int n = (int)Math.Sqrt(matrix.Length);
            int determinant = 0;

            if (n == 2)
            {
                determinant = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    int[,] subMatrix = new int[n - 1, n - 1];
                    for (int j = 1; j < n; j++)
                    {
                        for (int k = 0, l = 0; k < n; k++)
                        {
                            if (k != i)
                            {
                                subMatrix[j - 1, l] = matrix[j, k];
                                l++;
                            }
                        }
                    }

                    determinant += (int)Math.Pow(-1, i) * matrix[0, i] * GetMatrixDeterminant(subMatrix);
                }
            }

            return determinant;
        }

        private static int GetMatrixInverse(int[,] matrix, int[,] inverseMatrix)
        {
            int n = (int)Math.Sqrt(matrix.Length);
            int determinant = GetMatrixDeterminant(matrix);
            int determinantInverse = 0;
            int detInverseMod26 = 0;

            for (int i = 1; i < 26; i++)
            {
                if ((determinant * i) % 26 == 1)
                {
                    determinantInverse = i;
                    break;
                }
            }

            detInverseMod26 = (determinantInverse + 26) % 26;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int[,] subMatrix = new int[n - 1, n - 1];
                    int[,] cofactorMatrix = new int[n - 1, n - 1];

                    for (int k = 0, p = 0; k < n; k++)
                    {
                        if (k != i)
                        {
                            for (int l = 0, q = 0; l < n; l++)
                            {
                                if (l != j)
                                {
                                    subMatrix[p, q] = matrix[k, l];
                                    q++;
                                }
                            }

                            p++;
                        }
                    }

                    cofactorMatrix[i, j] = (int)Math.Pow(-1, i + j) * GetMatrixDeterminant(subMatrix);
                    inverseMatrix[j, i] = (cofactorMatrix[i, j] * detInverseMod26 + 26) % 26;
                }
            }

            return detInverseMod26;
        }

        public static string HillEncrypt(string plaintext, string key)
        {
            string encryptedText = "";

            int keySize = (int)Math.Sqrt(key.Length);
            int[,] keyMatrix = GenerateKeyMatrix(key.ToUpper());

            
            if (plaintext.Length % keySize != 0)
            {
                return encryptedText;
            }

            
            encryptedText = ApplyKeyMatrix(keyMatrix, plaintext.ToUpper());

            return encryptedText;
        }

        public static string HillDecrypt(string ciphertext, string key)
        {
            string decryptedText = "";

            int keySize = (int)Math.Sqrt(key.Length);
            int[,] keyMatrix = GenerateKeyMatrix(key.ToUpper());
            int[,] inverseMatrix = new int[keySize, keySize];

            int detInverseMod26 = GetMatrixInverse(keyMatrix, inverseMatrix);

            
            if (ciphertext.Length % keySize != 0 || detInverseMod26 == 0)
            {
                return decryptedText;
            }

            
            decryptedText = ApplyKeyMatrix(inverseMatrix, ciphertext.ToUpper());

            return decryptedText;
        }
    }

    public class BaconCipher
    {
        private static readonly Dictionary<char, string> baconAlphabet = new Dictionary<char, string>
    {
        {'A', "AAAAA"}, {'B', "AAAAB"}, {'C', "AAABA"}, {'D', "AAABB"}, {'E', "AABAA"},
        {'F', "AABAB"}, {'G', "AABBA"}, {'H', "AABBB"}, {'I', "ABAAA"}, {'J', "ABAAB"},
        {'K', "ABABA"}, {'L', "ABABB"}, {'M', "ABBAA"}, {'N', "ABBAB"}, {'O', "ABBBA"},
        {'P', "ABBBB"}, {'Q', "BAAAA"}, {'R', "BAAAB"}, {'S', "BAABA"}, {'T', "BAABB"},
        {'U', "BABAA"}, {'V', "BABAB"}, {'W', "BABBA"}, {'X', "BABBB"}, {'Y', "BBAAA"},
        {'Z', "BBAAB"}
    };

        public static string Encrypt(string plaintext)
        {
            StringBuilder encryptedText = new StringBuilder();

            foreach (char c in plaintext.ToUpper())
            {
                if (char.IsLetter(c))
                {
                    if (baconAlphabet.ContainsKey(c))
                    {
                        encryptedText.Append(baconAlphabet[c]);
                    }
                }
                else
                {
                    encryptedText.Append(c);
                }
            }

            return encryptedText.ToString();
        }

        public static string Decrypt(string ciphertext)
        {
            StringBuilder decryptedText = new StringBuilder();

            for (int i = 0; i < ciphertext.Length; i += 5)
            {
                string segment = ciphertext.Substring(i, Math.Min(5, ciphertext.Length - i));

                if (segment.Length == 5)
                {
                    char decodedChar = DecodeBaconSegment(segment);
                    decryptedText.Append(decodedChar);
                }
                else
                {
                    decryptedText.Append(segment);
                }
            }

            return decryptedText.ToString();
        }

        private static char DecodeBaconSegment(string segment)
        {
            foreach (KeyValuePair<char, string> pair in baconAlphabet)
            {
                if (pair.Value == segment)
                {
                    return pair.Key;
                }
            }

            return '?';
        }
    }

}
