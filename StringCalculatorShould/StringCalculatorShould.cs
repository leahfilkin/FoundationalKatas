using System;
using StringCalculator;
using Xunit;

namespace StringCalculatorShould
{
    public class StringCalculatorShould
    {
        [Fact]
        public void ReturnANumberWhenAddIsCalled()
        {
            // arrange
            var adder = new Adder();
            // act
            var output = adder.Add("");
            // assert
            Assert.Equal(0, output);
        }

        [Fact]
        public void ReturnTheSameNumberTheAddFunctionIsGiven()
        {
            // arrange
            var adder = new Adder();
            var number = "5";
            // act
            var output = adder.Add(number);
            // assert
            Assert.Equal(Convert.ToInt32(number), output);
        }

        [Fact]
        public void GiveSumWhenAddFunctionIsGivenAStringWithTwoNumbers()
        {
            var adder = new Adder();
            var numberString = "2,3";

            var output = adder.Add(numberString);
            
            Assert.Equal(5, output);
        }

        [Fact]
        public void GiveSumWhenAddFunctionIsGivenAStringWithAnyAmountOfNumbers()
        {
            var adder = new Adder();
            var numberString = "2,3,7,9";

            var output = adder.Add(numberString);
            
            Assert.Equal(21, output);
        }

        [Fact]
        public void GiveSumWhenAddFunctionInputHasLineBreaks()
        {
            var adder = new Adder();
            var numberString = "1,2\n3";
            
            var output = adder.Add(numberString);
            
            Assert.Equal(6, output);
        }

        [Fact]
        public void GiveSumWhenAddFunctionInputHasSpecifiedDelimiter()
        {
            var adder = new Adder();
            var numberString = "//;\n1;2";
            
            var output = adder.Add(numberString);
            
            Assert.Equal(3, output);
        }
    }
}