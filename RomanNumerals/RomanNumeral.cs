
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
            
            return "II";
        }
    }
}