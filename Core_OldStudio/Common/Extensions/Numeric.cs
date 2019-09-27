namespace Common.Extensions
{
    public static class Numeric
    {
        public static int ToInt(this string value)
        {
            return int.Parse(value);
        }

        public static double ToDouble(this string value)
        {
            return double.Parse(value);
        }
    }
}
