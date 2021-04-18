using System.Linq;

namespace MontyHallKata
{
    public class Game
    {
        private bool _didWin;

        public void PlayGame(IRandom random, Strategy strategy)
        {
            var doorGenerator = new DoorGenerator();
            var contestant = new Contestant();
            var monty = new Monty();

            var doors = doorGenerator.GenerateDoors(); 
            Door chosenDoor = contestant.ChooseDoor(random, doors);
            var doorsLeftToChoose = doors;
            var incorrectDoor = monty.GetIncorrectDoor(doors);
            if (strategy == Strategy.ChangeDoor)
            {
                doorsLeftToChoose.Remove(chosenDoor);
                doorsLeftToChoose.Remove(incorrectDoor);
                chosenDoor = doorsLeftToChoose.First();
            }
            _didWin = chosenDoor.HasPrize;
        }

        public int GetResult()
        {
            return _didWin ? 1 : 0;
        }
    }
}