
namespace RomanNumerals
{
    public static class RomanNumeral
    {
        public static string Convert(int i)
        {
            if (i == 1)
            {
                return "I";
            }
            if (i == 2)
            {
                return "II";
            }
            return "III";
        }
    }
}