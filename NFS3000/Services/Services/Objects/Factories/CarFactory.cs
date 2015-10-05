using Services.Services.Objects.Singletons;
using Services.ServicesContracts.Objects;

namespace Services.Services.Objects.Factories
{
    public class CarFactory : Factory
    {
        public override IDrawable CreatePositiveInstance(Coordinates coordinates)
        {
            var positiveInstance = new Car();
            positiveInstance.SetCarNumber(ScoreCounter.Instance().GetPlayerCount());
            return positiveInstance;
        }

        public override IDrawable CreateNegativeInstance(Coordinates coordinates)
        {
            var negativeInstance = new Car();
            negativeInstance.SetCarNumber(ScoreCounter.Instance().GetPlayerCount());
            return negativeInstance;
        }
    }
}
