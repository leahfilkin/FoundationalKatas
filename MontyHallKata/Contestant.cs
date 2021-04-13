using System.Collections.Generic;

namespace MontyHallKata
{
    public class Contestant
    {
        public Door ChooseDoor(IRandom random, List<Door> doors)
        {
            var randomIndex = random.Next(3) -1;
                return doors[randomIndex];
        }
    }
}