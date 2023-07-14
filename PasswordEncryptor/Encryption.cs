using System;
using System.Security.Cryptography;
using System.Text;

namespace PasswordEncryptor
{
    public class Encryption
    {
        /// <summary>
        /// Encripta una contraseña utilizando el algoritmo de hash MD5.
        /// </summary>
        /// <param name="password">La contraseña en texto plano a encriptar.</param>
        /// <returns>La contraseña encriptada como una cadena hexadecimal.</returns>
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

        /// <summary>
        /// Convierte un arreglo de bytes en una cadena hexadecimal.
        /// </summary>
        /// <param name="hashBytes">El arreglo de bytes a convertir.</param>
        /// <returns>La cadena hexadecimal resultante.</returns>
        private string ToMd5String(byte[] hashBytes)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }

            return sb.ToString();
        }


        /// <summary>
        /// Verifica si una contraseña coincide con su versión encriptada almacenada.
        /// </summary>
        /// <param name="password">La contraseña en texto plano a verificar.</param>
        /// <param name="hashedPassword">El hash de la contraseña almacenada.</param>
        /// <returns>True si la contraseña coincide, False en caso contrario.</returns>
        public bool VerifyPassword(string password, string hashedPassword)
        {
#warning La comparación se realiza sin tener en cuenta las diferencias de mayúsculas y minúsculas.
#warning El algoritmo de hash MD5 es considerado inseguro para almacenar contraseñas en producción.

            /*
             * Toma la contraseña en texto plano y utiliza el método HashMD5 para calcular el hash de la
             * contraseña ingresada. Luego, compara el hash calculado con el hash almacenado utilizando Equals.
             * La comparación se realiza sin tener en cuenta las diferencias de mayúsculas y minúsculas.
             */
            string inputHash = HashMD5(password);
            return inputHash.Equals(hashedPassword, StringComparison.OrdinalIgnoreCase);
        }
    }
}
