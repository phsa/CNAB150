namespace System
{
    public static class StringExtensions
    {
        public static string Fit(this string str, int lengthLimit, char charToFill, Func<string, int, char, string> fillingMethod)
        {
            if (str.Length > lengthLimit)
            {
                return str.Substring(0, lengthLimit);
            }
            else if (str.Length < lengthLimit)
            {
                return fillingMethod(str, lengthLimit, charToFill);
            }
            else
            {
                return str;
            }
        }
    }
}
