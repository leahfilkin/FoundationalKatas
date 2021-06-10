using System.Collections.Generic;
using Xunit;

namespace MarsRover.Console.Tests
{
    public class DecoderTests
    {
        [Fact]
        public static void ConvertsCharArrayToListOfCommands()
        {
            var commandInput = new[] {'f', 'l', 'b', 'r'};
            var decoder = new Decoder();
            var expected = new List<Command> {Command.Forward, Command.Left, Command.Backward, Command.Right};
            
            var actual = decoder.GetCommands(commandInput);
            
            Assert.Equal(expected, actual);
        }
    }
}