using System.Collections.Generic;
using Services.Services.Objects;

namespace Services.ServicesContracts.Objects
{
    public interface IDrawable
    {
        Coordinates Position { get; }
        int Priority { get; }
        IDictionary<Coordinates, char> Content { get; }
        /// <summary>
        /// Should be drawn on the map.
        /// </summary>
        /// <param name="screenTop">By Y map coordinate.</param>
        /// <param name="screenBottom">By Y map coordinate.</param>
        /// <returns></returns>
        bool ShouldBeDrawn(int screenTop, int screenBottom);
    }
}
