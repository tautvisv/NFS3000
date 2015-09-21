using Services.Services.Objects;

namespace Services.ServicesContracts.Objects
{
    interface ILocation
    {
        Coordinates GetPosition { get; }
    }
}
