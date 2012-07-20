using System;
using System.Text;

namespace Core
{
    public static class StringFunctions
    {
        public static string RemoveEscapeChars(this string original)
        {
            var sb = new StringBuilder();
            string[] parts = original.Split(new char[] { '\n', '\t', '\r', '\f', '\v' }, StringSplitOptions.RemoveEmptyEntries);
            int size = parts.Length;
            for (int i = 0; i < size; i++)
                sb.AppendFormat("{0}", parts[i]);
            return sb.ToString();
        }
    }
}
