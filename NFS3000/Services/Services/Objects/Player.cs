using System.Collections.Generic;

using Services.ServicesContracts.Objects;

namespace Services.Services.Objects
{
    public class Player : IPlayer
    {
        public string Name { get; set; }

        public ICar Car { get; set; }
        public Coordinates Position { get; private set; }
        public int Priority { get; private set; }
        public IDictionary<Coordinates, char> Content { get; private set; }
    }
}
