using System.Collections.Generic;

namespace MontyHallKata
{
    public class DoorGenerator
    {
        public List<Door> GenerateDoors(IRandom random)
        {
            var winningDoor = random.Next(3);
            var doors = new List<Door>();
            for (var i = 0; i < 3; i++)
            {
                if (i == winningDoor)
                {
                    var door = new Door(true);
                    doors.Add(door);
                }
                else
                {
                    var door = new Door(false);
                    doors.Add(door);
                }
            }
            return doors;
        }
    }
}