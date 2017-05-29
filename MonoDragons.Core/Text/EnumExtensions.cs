using System;
using System.Text.RegularExpressions;

namespace MonoDragons.Core.Text
{
    public static class EnumExtensions
    {
        public static string WithSpaces(this Enum src)
        {
            return Regex.Replace(src.ToString(), "(\\B[A-Z])", " $1");
        }
    }
}
