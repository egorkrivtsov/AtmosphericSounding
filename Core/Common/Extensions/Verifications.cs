using Common.Extensions.Converters;

namespace Common.Extensions
{
    public static class Verifications
    {
        public static bool ValidateLrc(this int valueToValidate, int valueToCompare)
        {
            valueToValidate = valueToValidate & 0xFF;
            int calculatedValue = ((valueToValidate ^ 0xFF) + 1) & 0xFF;
            return calculatedValue == valueToCompare;
        }

        public static bool ValidateLrcFromHex(this string tooValidate, string toCompare)
            =>  tooValidate.FromHex().ValidateLrc(toCompare.FromHex());
        

        public static bool ValidateCrc(this int valueToValidate, int valueToCompare)
        {
            return true;
        }

        public static bool ValidateCrcFromHex(this string tooValidate, string toCompare)
        {
            return true;
        }
    }
}
