using Xunit;

namespace MontyHallKata.Tests
{
    public class DoorTests
    {
        [Fact]
        public void IfDoorHasPrizeReturnTrue()
        {
            var door = new Door(true);

            Assert.True(door.HasPrize);
        }
    }
}

