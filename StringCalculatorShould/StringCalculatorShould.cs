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

        [Fact]
        public void ThrowErrorIfAddFunctionIsGivenNegativeNumber()
        {
            //arrange
            var adder = new Adder();
            var numberString = "-1,2,-3";

            //act
            //assert
            var exceptionMessage = Assert.Throws<ArgumentException>(() => adder.Add(numberString)).Message;
            Assert.Equal("Negatives not allowed: -1, -3", exceptionMessage);
        }

        [Fact]
        public void NotThrowExceptionWhenSlashIsLastCharacter()
        {
            var adder = new Adder();
            var numberString = "1,2,//";
            
            var output = adder.Add(numberString);
            
            Assert.Equal(3, output);
        }

        [Fact]
        public void IgnoreNumbersOver1000()
        {
            var adder = new Adder();
            var numberString = "1000,1001,2";
            
            var output = adder.Add(numberString);
            
            Assert.Equal(2, output);
        }

        [Fact]
        public void AcceptAnyLengthDelimiter()
        {
            var adder = new Adder();
            var numberString = "//[***]\n1***2***3";
            
            var output = adder.Add(numberString);   
            
            Assert.Equal(6, output);
        }

        [Fact]
        public void AcceptMultipleDelimitersOfSingleLength()
        {
            var adder = new Adder();
            var numberString = "//[*][%]\n1*2%3";
            
            var output = adder.Add(numberString);   
            
            Assert.Equal(6, output);
            
        }
        
        [Fact]
        public void AcceptMultipleDelimitersOfAnyLength()
        {
            var adder = new Adder();
            var numberString = "//[***][#][%]\n1***2#3%4";
            
            var output = adder.Add(numberString);   
            
            Assert.Equal(10, output);
        }
        
        [Fact]
        public void AcceptMultipleDelimitersOfAnyLengthWithNumbersIn()
        {
            var adder = new Adder();
            var numberString = "//[*1*][%]\n1*1*2%3";
            
            var output = adder.Add(numberString);   
            
            Assert.Equal(6, output);
        }

        [Fact]
        public void ThrowErrorWhenNumberOnEndOfDelimiter()
        {
            var adder = new Adder();
            var numberString = "//[DD1][%]\n1*1*2%3";
            
            var exceptionMessage = Assert.Throws<ArgumentException>(() => adder.Add(numberString)).Message;
            Assert.Equal("Edge numbers not allowed: DD1", exceptionMessage);        }
    }
}