using System.Collections.Generic;
using Services.ServicesContracts.Objects;

namespace Services.Services.Objects
{
    class Map : IMap
    {
        public Coordinates GlobalPosition { get; private set; }

        public int Priority { get; private set; }

        public IDictionary<Coordinates, char> Content { get; private set; }

        public bool UpdateScreen
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}
