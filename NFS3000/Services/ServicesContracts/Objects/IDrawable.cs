using System.Collections.Generic;
using Services.Services.Objects;

namespace Services.ServicesContracts.Objects
{
    public interface IDrawable
    {
        Coordinates GlobalPosition { get; }
        int Priority { get; }
        IDictionary<Coordinates, char> Content { get; }
    }
}
