namespace CoffeeMachine
{
    public abstract class CondimentDecorator : Drink
    {
        public new abstract string GetDescription();
        
        public abstract override double Cost();
    }
}