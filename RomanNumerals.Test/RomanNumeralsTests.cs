using System;
using System.Runtime.InteropServices;
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
        public void ConvertsIntegerToRomanNumeral(int toConvert, string expected)
        {
            var romanNumeral = RomanNumeral.Convert(toConvert);
            
            Assert.Equal(expected, romanNumeral);
        }
    }
}