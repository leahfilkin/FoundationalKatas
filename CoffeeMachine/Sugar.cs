namespace CoffeeMachine
{
    public class Sugar : CondimentDecorator
    {
        private readonly Drink _drink;

        public Sugar(Drink drink)
        {
            _drink = drink;
        }
        
        public override string GetDescription()
        {
            return _drink.GetDescription() + "with sugar and a stick";
        }
        public override double Cost()
        {
            return _drink.Cost();
        }
    }
}