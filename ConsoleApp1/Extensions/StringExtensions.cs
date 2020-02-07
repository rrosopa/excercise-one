using System;
using System.Linq;

namespace ConsoleApp1.Extensions
{
    public static class StringExtensions
    {        
        public static string ReplacePunctuations(this string sourceString, char replaceValue = ' ')
        {
            var result = string.Empty;
            foreach(var c in sourceString.ToCharArray())
            {
                result += char.IsPunctuation(c) ? replaceValue : c;
            }

            return result;
        }

        public static string CleanSpacesInBetween(this string sourceString) => string.Join(" ", sourceString.Split(' ', StringSplitOptions.RemoveEmptyEntries));

        public static string ReverseSentence(this string sourceString) => string.Join(' ', sourceString.Split(' ').Reverse());
    }
}
