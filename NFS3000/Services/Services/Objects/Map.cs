using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Data;

using Newtonsoft.Json;

using Services.Services.Objects.Factories;
using Services.ServicesContracts.Objects;
using Services.Trash;

namespace Services.Services.Objects
{
    class Map : IMap
    {
        private Factory carFactory = new CarFactory();
        private Factory obsticlesFactory = new ObsticlesFactory();
        private IList<IDrawable> obsticles = new List<IDrawable>();
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Map(Factory carFactory, Factory obsticlesFactory)
        {
            this.carFactory = carFactory;
            this.obsticlesFactory = obsticlesFactory;
            var jsonText = File.ReadAllText(Globals.MODELS_PATH + "asd" + Globals.MODELS_FILES_EXTENSION);
            var deserializeObject = JsonConvert.DeserializeObject<MapStructure>(jsonText);
            Width = deserializeObject.MapWidth;
            Height = deserializeObject.MapLength;
            foreach (var mapObject in deserializeObject.map)
            {

                switch (mapObject.ClassType)
                {
                    case "Services.Services.Objects.Obsticle":
                        TakeObject(obsticlesFactory, mapObject);
                        break;
                    default:
                        return;
                }
            }
        }

        private void TakeObject(Factory obsticlesFactory, MapObjects mapObject)
        {
            foreach (var coordinates in mapObject.Positions)
            {
                obsticles.Add(obsticlesFactory.CreateNegativeInstance(coordinates));
            }
        }

        public Coordinates Position { get; private set; }
        public void MoveLeft()
        {
            throw new System.NotImplementedException();
        }

        public void MoveRight()
        {
            throw new System.NotImplementedException();
        }

        public void MoveUp()
        {
            throw new System.NotImplementedException();
        }

        public void MoveDown()
        {
            throw new System.NotImplementedException();
        }

        public int Priority { get; private set; }

        public IDictionary<Coordinates, char> Content { get; private set; }
    }
}
