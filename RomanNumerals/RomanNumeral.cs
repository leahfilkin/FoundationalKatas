
namespace RomanNumerals
{
    public static class RomanNumeral
    {
        public static string Convert(int i)
        {
            return i switch
            {
                1 => "I",
                2 => "II",
                3 => "III",
                4 => "IV",
                5 => "V",
                6 => "VI",
                7 => "VII",
                8 => "VIII",
                9 => "IX",
                _ => "X"
            };
        }
    }
}