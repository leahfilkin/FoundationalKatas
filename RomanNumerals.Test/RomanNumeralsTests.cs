using System;
using Xunit;

namespace RomanNumerals.Test
{
    public class RomanNumeralsTests
    {
        [Fact]
        public void Converts1ToI()
        {
            var romanNumeral = RomanNumeral.Convert(1);
            
            Assert.Equal("I", romanNumeral);
        }

        [Fact]
        public void Converts2ToII()
        {
            var romanNumeral = RomanNumeral.Convert(2);

            Assert.Equal("II", romanNumeral);
        }
    }
}