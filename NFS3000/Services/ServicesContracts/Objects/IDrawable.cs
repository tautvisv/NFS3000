using System.Collections.Generic;
using Services.Services.Objects;

namespace Services.ServicesContracts.Objects
{
    interface IDrawable
    {
        int Priority { get; }
        IDictionary<Coordinates, char> Content { get; }
        bool UpdatesNeeded { get; }
    }
}
