using System.Linq;

namespace MontyHallKata
{
    public class Game
    {
        public int PlayGame(IRandom random, Strategy strategy)
        {
            var doorGenerator = new DoorGenerator();
            var contestant = new Contestant();
            var monty = new Monty();

            var doors = doorGenerator.GenerateDoors(); 
            Door chosenDoor = contestant.ChooseDoor(random, doors);
            var incorrectDoor = monty.GetIncorrectDoor(doors);
            if (strategy == Strategy.ChangeDoor)
            {
                chosenDoor = doors.First(x => x != chosenDoor && x != incorrectDoor);
            }
            return chosenDoor.HasPrize ? 1 : 0;
        }
    }
}