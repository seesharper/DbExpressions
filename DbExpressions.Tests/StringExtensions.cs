using System;

namespace DbExpressions.Tests
{
    public static class StringExtensions
    {
        public static string Clean(this string target)
        {
            return target.Replace(Environment.NewLine, "").Replace("\t", "");
        }

        /// <summary>
        /// Strips of the formatting (new line and tabs) 
        /// </summary>
        /// <param name="target">The target string.</param>
        /// <returns><see cref="string"/></returns>
        public static string Strip(this string target)
        {
            return target.Replace(Environment.NewLine, "").Replace("\t", "");
        }
    }
}
