
using System;

namespace RomanNumerals
{
    public static class RomanNumeral
    {
        public static string Convert(int i)
        {
            if (i <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(i), "Number must be greater than zero");
            }
            return ConvertThousands(i) + ConvertHundreds(i) + ConvertTens(i) + ConvertOnes(i);
        }

        private static string ConvertOnes(int i)
        {
            var ones = i % 10;
            return ones switch
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
                _ => ""
            };
        }

        private static string ConvertTens(int i)
        {
            var tens = i / 10 % 10;
            return tens switch
            {
                1 => "X",
                2 => "XX",
                3 => "XXX",
                4 => "XL",
                5 => "L",
                6 => "LX",
                7 => "LXX",
                8 => "LXXX",
                9 => "XC",
                _ => ""
            };
        }
        private static string ConvertHundreds(int i)
        {
            var hundreds = i / 100 % 10;
            return hundreds switch
            {
                1 => "C",
                2 => "CC",
                3 => "CCC",
                4 => "CD",
                5 => "D",
                6 => "DC",
                7 => "DCC",
                8 => "DCCC",
                9 => "CM",
                _ => ""
            };
        }

        private static string ConvertThousands(int i)
        {
            var thousands = i / 1000;
            return thousands switch
            {
                1 => "M",
                2 => "MM",
                3 => "MMM",
                _ => ""
            };
        }
    }
}