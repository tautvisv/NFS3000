using System.Collections.Generic;
using Data;
using Services.Services.Objects.Singletons;
using Services.ServicesContracts.Objects;

namespace Services.Services.Objects
{
    public class Car : ICar
    {
        public Car()
        {
            Content = ModelLoader.Instance().LoadModel(Globals.MODELS_PATH + "Car" + Globals.MODELS_FILES_EXTENSION);
            Priority = 100;
        }

        public Coordinates Position { get; protected set; }

        public Coordinates GlobalPosition { get; protected set; }
        public int Priority { get; protected set; }

        public IDictionary<Coordinates, char> Content { get; protected set; }

        public string Name { get; set; }

        public Engine Engine { get; set; }

        public Body Body { get; set; }

        public Tire Tires { get; set; }

        public IUsable Usable { get; set; }
    }
}
