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
            //arrange
            var adder = new Adder();
            //act
            var output = adder.Add("");
            //assert
            Assert.Equal(0, output);
        }

        [Fact]
        public void ReturnTheSameNumberTheAddFunctionIsGiven()
        {
            var adder = new Adder();
            var number = "5";
            //act
            var output = adder.Add(number);
            //assert
            Assert.Equal(Convert.ToInt32(number), output);
        }
    }
}