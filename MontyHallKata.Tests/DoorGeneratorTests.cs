using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace MontyHallKata.Tests
{
    public class DoorGeneratorTests
    {
        [Fact]
        public void GameHasThreeDoors()
        {
            var doorGenerator = new DoorGenerator();
            var random = new Random();
            var doors = doorGenerator.GenerateDoors(random);
            
            Assert.Equal(3, doors.Count);
        }
        
        [Fact]
        public void OnlyOneDoorHasPrize()
        {
            var doorGenerator = new DoorGenerator();
            var random = new Random();
            var doors = doorGenerator.GenerateDoors(random);
            Assert.Single(doors.Where(door => door.HasPrize));
        }
        
        [Theory]
        [InlineData(new int[] {2,1,0})]
        public void UsesRandomNumberToCreateWinningDoor(int[] randomDoors)
        {
            var doorGenerator = new DoorGenerator();
            var random = new FakeRandom(randomDoors.ToList());
            var doors = doorGenerator.GenerateDoors(random);
            
            Assert.True(doors[randomDoors.First()].HasPrize);

        }
        
    }
}