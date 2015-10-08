using Services.Services.Objects;

namespace Services.ServicesContracts.Objects
{
    public interface IMap : IDrawable, IMove
    {
        int Width { get; }
        int Height { get; }
        Coordinates Position { get; }
    }
}
