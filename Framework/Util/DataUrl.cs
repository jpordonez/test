using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Framework.Util
{
    public class DataUrl
    {
        public static byte[] GetData(string dataUrl)
        {
            if (dataUrl == null)
                return null;
            var base64Data = Regex.Match(dataUrl, @"data:(?<type>.+?);base64,(?<data>.+)").Groups["data"].Value;
            var binData = Convert.FromBase64String(base64Data);
            return binData;
        }

        public static string GetFileType(string dataUrl)
        {
            if (dataUrl == null)
                return null;
            var typeData = Regex.Match(dataUrl, @"data:(?<type>.+?);base64,(?<data>.+)").Groups["type"].Value;
            return typeData;
        }

        public static string FromFileTypeAndBytes(string fileType, byte[] data)
        {
            if (fileType == null || data == null)
                return null;
            var dataUrl = "data:" + fileType + ";base64," + Convert.ToBase64String(data);
            return dataUrl;
        }

    }
}
