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
        public void ConvertsIntegerUnder10ToRomanNumeral(int toConvert, string expected)
        {
            var romanNumeral = RomanNumeral.Convert(toConvert);
            
            Assert.Equal(expected, romanNumeral);
        }
        
        [Theory]
        [InlineData(10, "X")]
        [InlineData(11, "XI")]
        [InlineData(39, "XXXIX")]
        [InlineData(40, "XL")]
        [InlineData(49, "XLIX")]
        [InlineData(50, "L")]
        [InlineData(63, "LXIII")]
        [InlineData(74, "LXXIV")]
        [InlineData(89, "LXXXIX")]
        [InlineData(99, "XCIX")]
        public void ConvertsIntegerFrom10To99ToRomanNumeral(int toConvert, string expected)
        {
            var romanNumeral = RomanNumeral.Convert(toConvert);
            
            Assert.Equal(expected, romanNumeral);
        }

        [Theory]
        [InlineData(100, "C")]
        [InlineData(191, "CXCI")]
        [InlineData(282, "CCLXXXII")]
        [InlineData(373, "CCCLXXIII")]
        [InlineData(464, "CDLXIV")]
        [InlineData(555, "DLV")]
        [InlineData(646, "DCXLVI")]
        [InlineData(737, "DCCXXXVII")]
        [InlineData(828, "DCCCXXVIII")]
        [InlineData(919, "CMXIX")]
        public void ConvertsInteger100To999ToRomanNumeral(int toConvert, string expected)
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