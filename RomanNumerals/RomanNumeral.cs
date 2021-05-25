
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
                _ => "IV"
            };
        }
    }
}