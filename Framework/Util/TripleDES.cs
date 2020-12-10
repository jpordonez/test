using System;
using System.Security.Cryptography;
using System.Text;

namespace Framework.Util
{
    public class TripleDES
    {
        /*********************************/
        /// <summary>
        /// Método para encriptar con 3DES usando como key un valor en MD5
        /// </summary>
        /// <param name="toEncrypt">cadena a encriptar</param>
        /// <returns>retorna la cadena encriptada</returns>
        public static string Encode(string toEncrypt, string securityKeyMD5)
        {
            bool useHashing = true;
            string retVal = string.Empty;
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);
            // Validate inputs
            ValidateInput(toEncrypt);
            ValidateInput(securityKeyMD5);
            // If hashing use get hashcode regards to your key
            if (useHashing)
            {
                var hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(securityKeyMD5));
                // Always release the resources and flush data
                // of the Cryptographic service provide. Best Practice
                hashmd5.Clear();
            }
            else
            {
                keyArray = UTF8Encoding.UTF8.GetBytes(securityKeyMD5);
            }
            var tdes = new TripleDESCryptoServiceProvider();
            // Set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            // Mode of operation. there are other 4 modes.
            // We choose ECB (Electronic code Book)
            tdes.Mode = CipherMode.ECB;
            // Padding mode (if any extra byte added)
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateEncryptor();
            // Transform the specified region of bytes array to resultArray
            byte[] resultArray =
              cTransform.TransformFinalBlock(toEncryptArray, 0,
              toEncryptArray.Length);

            // Release resources held by TripleDes Encryptor
            tdes.Clear();
            // Return the encrypted data into unreadable string format
            retVal = Convert.ToBase64String(resultArray, 0, resultArray.Length);
            return retVal;
        }

        public static string Decode(string cipherString, string securityKeyMD5)
        {
            bool useHashing = true;
            byte[] keyArray;
            //get the byte code of the string

            byte[] toEncryptArray = Convert.FromBase64String(cipherString);            

            if (useHashing)
            {
                //if hashing was used get the hash code with regards to your key
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(securityKeyMD5));
                //release any resource held by the MD5CryptoServiceProvider

                hashmd5.Clear();
            }
            else
            {
                //if hashing was not implemented get the byte code of the key
                keyArray = UTF8Encoding.UTF8.GetBytes(securityKeyMD5);
            }

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes. 
            //We choose ECB(Electronic code Book)

            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(
                                 toEncryptArray, 0, toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor                
            tdes.Clear();
            //return the Clear decrypted TEXT
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        /// <summary>
        /// Método para validar las cadenas ingresadas que no sean vacias
        /// </summary>
        /// <param name="inputValue">cadena ingresada</param>
        /// <returns>true si es correcta o false si es errónea</returns>
        private static bool ValidateInput(string inputValue)
        {
            var invalid = string.IsNullOrEmpty(inputValue);
            if (invalid)
            {
                throw new System.Exception("inputValue es nulo o vacio");
            }
            return invalid;
        }
    }
}
