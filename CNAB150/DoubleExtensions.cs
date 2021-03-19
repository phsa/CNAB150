namespace System
{
    public static class DoubleExtensions
    {
        public static string ToStandardizedString(this double d, int lenghtLimit, char charToFill, Func<string, int, char, string> fillingMode)
        {
            string noFloatPoint = ((int)(100 * d)).ToString();
            return noFloatPoint.Fit(lenghtLimit, charToFill, fillingMode);
        }
    }
}
