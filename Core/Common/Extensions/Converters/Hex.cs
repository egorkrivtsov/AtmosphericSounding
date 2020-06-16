namespace Common.Extensions.Converters
{
    public static class Hex
    {
        public static int FromHex(this string hexValue) => 
            int.Parse(hexValue, System.Globalization.NumberStyles.HexNumber);

        public static string ToHex(this int intValue) => intValue.ToString("X");
        
    }
}