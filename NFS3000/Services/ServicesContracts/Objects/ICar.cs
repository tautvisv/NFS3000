using Services.Services.Objects;

namespace Services.ServicesContracts.Objects
{
    public interface ICar : ILocation, IDrawable, IMovable
    {
        string Name { get; set; }

        IEngine Engine { get; set; }

        IBody Body { get; set; }

        ITires Tires { get; set; }

        IUsable Usable { get; set; }

        void SetCarNumber(int number);
    }
}
