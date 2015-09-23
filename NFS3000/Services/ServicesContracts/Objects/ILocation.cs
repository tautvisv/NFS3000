using Services.Services.Objects;

namespace Services.ServicesContracts.Objects
{
    public interface ILocation
    {
        Coordinates GetPosition { get; }
    }
}
