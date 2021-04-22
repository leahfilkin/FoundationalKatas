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
            var doors = doorGenerator.GenerateDoors();
            
            Assert.Equal(3, doors.Count);
        }
        
        [Fact]
        public void OnlyOneDoorHasPrize()
        {
            var doorGenerator = new DoorGenerator();
            var doors = doorGenerator.GenerateDoors();
            Assert.Single(doors.Where(door => door.HasPrize));
        }
    }
}