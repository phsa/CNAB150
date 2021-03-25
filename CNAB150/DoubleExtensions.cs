namespace System
{
    public static class DoubleExtensions
    {
        public static string ToStandardizedString(this double d)
        {
            string noFloatPoint = ((int)(100 * d)).ToString();
            return noFloatPoint;
        }
    }
}
