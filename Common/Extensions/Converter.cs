namespace Common.Extensions
{
    public static class Converter
    {
        public static int FromHex(this string hexValue)
        {
            return int.Parse(hexValue, System.Globalization.NumberStyles.HexNumber);
        }

        public static string ToHex(this int intValue)
        {
            return intValue.ToString("X");
        }
    }
}