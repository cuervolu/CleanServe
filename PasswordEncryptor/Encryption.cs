using System;
using System.Security.Cryptography;
using System.Text;

namespace PasswordEncryptor
{
    public class Encryption
    {
        /// Encripta una contraseña utilizando el algoritmo de hash MD5.
        public string HashMD5(string password)
        {
            try
            {
                using (MD5 md5 = MD5.Create())
                {
                    byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                    byte[] hashBytes = md5.ComputeHash(passwordBytes);
                    return ToMd5String(hashBytes);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al encriptar la contraseña con MD5.", ex);
            }
        }


        /// Convierte un array de bytes en una cadena hexadecimal.
        private string ToMd5String(byte[] hashBytes)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
