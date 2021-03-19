﻿namespace CNAB150
{
    public static class StringUtils
    {
        public static string FillAtEnd(string str, int lengthLimit, char charToFill)
        {
            return str.PadRight(lengthLimit, charToFill);
        }

        public static string FillAtStart(string str, int lengthLimit, char charToFill)
        {
            return str.PadLeft(lengthLimit, charToFill);
        }
    }
}