namespace Common.Extensions.Converters
{
    public static class Numeric
    {
        public static int ToInt(this string value) => int.Parse(value);

        public static double ToDouble(this string value) => double.Parse(value);
    }
}
