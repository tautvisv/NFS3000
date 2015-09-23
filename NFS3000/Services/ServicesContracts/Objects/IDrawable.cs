using System.Collections.Generic;
using Services.Services.Objects;

namespace Services.ServicesContracts.Objects
{
    public interface IDrawable
    {
        int Priority { get; }
        IDictionary<Coordinates, char> Content { get; }
        bool UpdateScreen { get; }
    }
}
