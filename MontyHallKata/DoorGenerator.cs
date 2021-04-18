using System.Collections.Generic;

namespace MontyHallKata
{
    public class DoorGenerator
    {
        public List<Door> GenerateDoors()
        {
            var doors = new List<Door>();
            for (var i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    var door = new Door(true, true);
                    doors.Add(door);
                }
                else
                {
                    var door = new Door(false, false);
                    doors.Add(door);
                }
            }
            return doors;
        }
    }
}