using Services.Services.Objects;

namespace Services.ServicesContracts.Objects
{
    public interface ICar : ILocation, IDrawable, IMovable
    {
        string Name { get; set; }

        IItem Engine { get; set; }

        IItem Body { get; set; }

        IItem Tires { get; set; }

        IUsable Usable { get; set; }

        void SetCarNumber(int number);
    }
}
