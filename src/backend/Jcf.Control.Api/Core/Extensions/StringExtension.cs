using System.Text.RegularExpressions;

namespace Jcf.Control.Api.Core.Extensions
{
    public static class StringExtension
    {
        public static string OnlyNumbers(this string? str)
        {
            if (str == null) return string.Empty;
            return Regex.Replace(str, "[^0-9]", "");
        }

        public static string FirstPart(this string str)
        {
            if (str == null) return string.Empty;
            string[] parts = str.Split(' ');
            return parts[0];
        }
    }
}
