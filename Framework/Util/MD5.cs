using System;
using System.Security.Cryptography;
using System.Text;

namespace Framework.Util
{
    public class MD5
    {
        /// <summary>
        /// Permite obtener el valor hash MD5 de una cadena en base 64
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Encode(string value)
        {
            var x = new MD5CryptoServiceProvider();
            var data = UTF8Encoding.UTF8.GetBytes(value);
            data = x.ComputeHash(data);
            var result = Convert.ToBase64String(data, 0, data.Length);
            return result;
        }

    }
}
