using System;
using StringCalculator;
using Xunit;

namespace StringCalculatorShould
{
    public class Tests
    {
        [Fact]
        public void ReturnANumberWhenAddIsCalled()
        {
            //arrange
            Adder adder = new Adder();
            
            //act
            var output = adder.Add("");
            //assert
            Assert.Equal(0, output);
        }
    }
}