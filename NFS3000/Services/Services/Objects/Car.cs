using System.Collections.Generic;
using Services.ServicesContracts.Objects;

namespace Services.Services.Objects
{
    public class Car : ICar
    {
        public Car()
        {
            Priority = 100;
        }

        public Coordinates GetPosition { get; private set; }

        public Coordinates GlobalPosition { get; private set; }
        public int Priority { get; private set; }

        public IDictionary<Coordinates, char> Content { get; private set; }

        public string Name { get; set; }

        public Engine Engine { get; set; }

        public Body Body { get; set; }

        public Tire Tires { get; set; }

        public IUsable Usable { get; set; }
    }
}
