using Services.Services.Objects.Singletons;
using Services.ServicesContracts.Objects;

namespace Services.Services.Objects.Factories
{
    public class PlayerFactory : Factory
    {
        public override IDrawable CreatePositiveInstance(Coordinates coordinates)
        {
            var positiveInstance = new Player();
            ScoreCounter.Instance().AddPlayer(positiveInstance);
            return positiveInstance;
        }

        public override IDrawable CreateNegativeInstance(Coordinates coordinates)
        {
            var negativeInstance = new Player();
            ScoreCounter.Instance().AddPlayer(negativeInstance);
            return negativeInstance;
        }
    }
}
