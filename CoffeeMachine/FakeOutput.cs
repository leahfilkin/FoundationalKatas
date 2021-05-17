using System.Linq;

namespace CoffeeMachine
{
    public class FakeOutput : IOutput
    {
        public string OutputString = "";

        public void DisplayOrderInformation(Ticket ticket)
        {
            var drinkName = Output.ToString(ticket.DrinkType);
            OutputString = string.Join(" ", new [] {"Drink maker makes 1", drinkName, Output.GetSugarAndStickDescription(ticket)}
                .Where(x => x != ""));
        }
    }
}