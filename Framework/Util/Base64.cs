using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Framework.Util
{
    public class Base64
    {
        public static string Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static string Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static string EncodeUrl(string textoBase64)
        {
            return Base64UrlEncoder.Encode(textoBase64);
        }

        public static string DecodeUrl(string codificadoUrlBase64)
        {            
            return Base64UrlEncoder.Decode(codificadoUrlBase64);
        }

    }
}
