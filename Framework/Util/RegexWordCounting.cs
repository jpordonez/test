using System.Text.RegularExpressions;

namespace Framework.Util
{
    public class RegexWordCounting : IWordCounting
    {

        public int CountWords(string text)
        {
            var regex = new Regex(@"\w+", RegexOptions.Compiled);
            return regex.Matches(text).Count;
        }
    }
}
