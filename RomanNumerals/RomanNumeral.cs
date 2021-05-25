
namespace RomanNumerals
{
    public static class RomanNumeral
    {
        public static string Convert(int i)
        {
            var tens = i / 10;
            var ones = i % 10;
            var numberList = new int[] {tens, ones};
            
            var result = "";

            foreach (var number in numberList)
            {
                result += number switch
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
                    10 => "X",
                    _ => ""
                };
            }

            return result;
        }

        public static string NumberOfTens(int i)
        {
            var tens = i / 10;
            for (int x; x < tens; )
        }
    }
}