using Services.ServicesContracts.Objects;

namespace Services.Services.Objects.Factories
{
    public class ObsticlesFactory : Factory
    {
        public override IDrawable CreatePositiveInstance(Coordinates coordinates)
        {
            throw new System.NotImplementedException();
        }

        public override IDrawable CreateNegativeInstance(Coordinates coordinates)
        {
            var negativeInstance = new Obsticle();
            return negativeInstance;
        }
    }
}
