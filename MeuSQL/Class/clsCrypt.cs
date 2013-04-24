using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Security.Cryptography;

namespace MeuSQL.Class
{
    class clsCrypt
    {

        private static TripleDESCryptoServiceProvider TripleDES = new TripleDESCryptoServiceProvider();

        private static MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
        // Definição da chave de encriptação/desencriptação

        private const string key = "CHAVE12345teste";
        /// <summary>
        /// Calcula o MD5 Hash
        /// </summary>
        /// <param name="value">Chave</param>
        public static byte[] MD5Hash(string value)
        {

            // Converte a chave para um array de bytes
            byte[] byteArray = ASCIIEncoding.ASCII.GetBytes(value);
            return MD5.ComputeHash(byteArray);

        }

        /// <summary>
        /// Encripta uma string com base em uma chave
        /// </summary>
        /// <param name="stringToEncrypt">String a encriptar</param>
        public static string Encrypt(string stringToEncrypt, string strKey)
        {
            try
            {
                // Definição da chave e da cifra (que neste caso é Electronic
                // Codebook, ou seja, encriptação individual para cada bloco)
                TripleDES.Key = clsCrypt.MD5Hash(strKey);
                TripleDES.Mode = CipherMode.ECB;

                // Converte a string para bytes e encripta
                byte[] Buffer = ASCIIEncoding.ASCII.GetBytes(stringToEncrypt);
                return Convert.ToBase64String(TripleDES.CreateEncryptor().TransformFinalBlock(Buffer, 0, Buffer.Length));

            }
            catch (Exception ex)
            {
                throw (ex);
                return string.Empty;

            }

        }



        /// <summary>
        /// Desencripta uma string com base em uma chave
        /// </summary>
        /// <param name="encryptedString">String a decriptar</param>
        public static string Decrypt(string encryptedString, string strKey)
        {
            try
            {
                // Definição da chave e da cifra
                TripleDES.Key = clsCrypt.MD5Hash(strKey);
                TripleDES.Mode = CipherMode.ECB;

                // Converte a string encriptada para bytes e decripta
                byte[] Buffer = Convert.FromBase64String(encryptedString);
                return ASCIIEncoding.ASCII.GetString(TripleDES.CreateDecryptor().TransformFinalBlock(Buffer, 0, Buffer.Length));
            }
            catch (Exception ex)
            {
                throw (ex);                               
                return string.Empty;
            }

        }
    }
}
