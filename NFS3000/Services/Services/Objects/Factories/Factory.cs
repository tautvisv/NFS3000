using Services.ServicesContracts.Objects;

namespace Services.Services.Objects.Factories
{
    public abstract class Factory
    {
        public abstract IDrawable CreatePositiveInstance(Coordinates coordinates);
        public abstract IDrawable CreateNegativeInstance(Coordinates coordinates);
    }
}
