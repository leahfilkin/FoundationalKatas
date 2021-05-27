using System;
using Xunit;

namespace RomanNumerals.Test
{
    public class RomanNumeralsTests
    {
        [Theory]
        [InlineData(1, "I")]
        [InlineData(2, "II")]
        [InlineData(3, "III")]
        [InlineData(4, "IV")]
        [InlineData(5, "V")]
        [InlineData(6, "VI")]
        [InlineData(7, "VII")]
        [InlineData(8, "VIII")]
        [InlineData(9, "IX")]
        [InlineData(10, "X")]
        [InlineData(11, "XI")]
        [InlineData(39, "XXXIX")]
        [InlineData(40, "XL")]
        public void ConvertsIntegerToRomanNumeral(int toConvert, string expected)
        {
            var romanNumeral = RomanNumeral.Convert(toConvert);
            
            Assert.Equal(expected, romanNumeral);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-50)]
        public void ThrowsForNumbersLessThanOne(int toConvert)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => RomanNumeral.Convert(toConvert));
        }
    }
}