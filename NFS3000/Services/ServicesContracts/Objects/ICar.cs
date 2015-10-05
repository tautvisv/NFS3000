using Services.Services.Objects;

namespace Services.ServicesContracts.Objects
{
    public interface ICar : ILocation, IDrawable, IMovable
    {
        string Name { get; set; }

        Engine Engine { get; set; }

        Body Body { get; set; }

        Tire Tires { get; set; }

        IUsable Usable { get; set; }

        void SetCarNumber(int number);
    }
}
