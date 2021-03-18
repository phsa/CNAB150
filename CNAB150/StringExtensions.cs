namespace System
{
    public static class StringExtensions
    {

        public static string Fit(this string str, int lenghtLimit, char charToFill, Func<int, char, string> fillingMode)
        {
            if (str.Length > lenghtLimit)
            {
                return str.Substring(0, lenghtLimit);
            }
            else if (str.Length < lenghtLimit)
            {
                return fillingMode(lenghtLimit, charToFill);
            }
            else
            {
                return str;
            }
        }
    }
}
