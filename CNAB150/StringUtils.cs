namespace CNAB150
{
    public static class StringUtils
    {
        public static string FillAtEnd(string str, int lengthLimit, char fillerChar)
        {
            return str.PadRight(lengthLimit, fillerChar);
        }

        public static string FillAtStart(string str, int lengthLimit, char fillerChar)
        {
            return str.PadLeft(lengthLimit, fillerChar);
        }

        public static string TruncateFromStart(string str, int length)
        {
            return str.Substring(0, length);
        }

        public static string TruncateFromEnd(string str, int length)
        {
            return str.Substring(str.Length - length, length);
        }

        public static string TruncateAtSides(string str, int length)
        {
            return str.Substring((str.Length - length) / 2, length);
        }
    }
}
