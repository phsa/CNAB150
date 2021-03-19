namespace System
{
    public static class StringExtensions
    {
        public static string Fit(this string str, int lenghtLimit, char charToFill, Func<string, int, char, string> fillingMethod)
        {
            if (str.Length > lenghtLimit)
            {
                return str.Substring(0, lenghtLimit);
            }
            else if (str.Length < lenghtLimit)
            {
                return fillingMethod(str, lenghtLimit, charToFill);
            }
            else
            {
                return str;
            }
        }
    }
}
