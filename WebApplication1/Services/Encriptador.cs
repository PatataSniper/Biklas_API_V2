using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Biklas_API_V2.Services
{
    public class Encriptador : IEncriptador
    {
        public byte[] Llave => new byte[32] { 106, 239, 13, 143, 243, 179, 229, 198,
            205, 213, 57, 28, 38, 55, 68, 86, 193, 173, 192, 117, 247, 21, 197, 63,
            80, 94, 2, 234, 179, 27, 106, 249 };

        public byte[] IV => new byte[16] { 217, 123, 54, 183, 55, 178, 250, 77, 116, 
            176, 159, 56, 108, 214, 253, 146 };

        public byte[] Encriptar(string textoPlano, byte[] llave, byte[] IV)
        {
            // Código gracias a la documentación oficial de Microsoft:
            // https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.aes?view=net-6.0
            // Check arguments.
            if (textoPlano == null || textoPlano.Length <= 0)
                throw new ArgumentNullException("textoCifrado");
            if (llave == null || llave.Length <= 0)
                throw new ArgumentNullException("llave");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = llave;
                aesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(textoPlano);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream converted to string.
            return encrypted;
        }

        public string Desencriptar(byte[] textoCifrado, byte[] llave, byte[] IV)
        {
            // Código gracias a la documentación oficial de Microsoft:
            // https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.aes?view=net-6.0
            // Check arguments.
            if (textoCifrado == null || textoCifrado.Length <= 0)
                throw new ArgumentNullException("textoCifrado");
            if (llave == null || llave.Length <= 0)
                throw new ArgumentNullException("llave");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string? plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = llave;
                aesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(textoCifrado))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }
    }
}