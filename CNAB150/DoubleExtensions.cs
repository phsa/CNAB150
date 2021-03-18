namespace System
{
    public static class DoubleExtensions
    {
        public static string Normalize(this double d)
        {
            return ((int)(100 * d)).ToString();
        }
    }
}
