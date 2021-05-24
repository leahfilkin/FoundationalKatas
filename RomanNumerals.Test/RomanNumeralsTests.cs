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
    }
}