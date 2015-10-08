using System.Collections.Generic;

using Services.ServicesContracts.Objects;

namespace Services.Services.Objects
{
    public class Obsticle : IObsticle
    {
        public Coordinates Position { get; private set; }
        public int Priority { get; private set; }
        public IDictionary<Coordinates, char> Content { get; private set; }
        public IItem Collect()
        {
            throw new System.NotImplementedException();
        }

        public void Move()
        {
            throw new System.NotImplementedException();
        }
    }
}
