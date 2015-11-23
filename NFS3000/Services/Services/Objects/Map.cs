using System.Collections.Generic;
using System.IO;

using Data;

using Newtonsoft.Json;

using Services.Services.Objects.Factories;
using Services.Services.Objects.Singletons;
using Services.ServicesContracts.Objects;
using Services.Trash;

namespace Services.Services.Objects
{
    public class Map : AIObject, IMap
    {
        private Factory carFactory = new CarFactory();
        private Factory obsticlesFactory = new ObsticlesFactory();
        private IList<IDrawable> obsticles = new List<IDrawable>();
        private readonly PhysicsEngine physicsEngine;
        public int Width { get; private set; }
        public int Height { get; private set; }
        private readonly char[][] mapFences = new char[2][];
        public Map(PhysicsEngine physicsEngine)
        {
            physicsEngine.AddItem(this);
            this.physicsEngine = physicsEngine;
            RequeredTicksToMove = 3;
            Position = new Coordinates();
            Content = new Dictionary<Coordinates, char>();
            for (int i = 0; i < mapFences.Length; i++)
            {
                mapFences[i] = new char[Globals.Y_MAX_BOARD_SIZE];
                for (int j = 0; j < mapFences[i].Length; j++)
                {
                    mapFences[i][j] = j % 3 == 1 ? Globals.BACKGROUND_DEFAULT_VALUE : '+';
                }
            }
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
            RecreateFences();
        }

        private void TakeObject(Factory obsticlesFactory, MapObjects mapObject)
        {
            foreach (var coordinates in mapObject.Positions)
            {
                obsticles.Add(obsticlesFactory.CreateNegativeInstance(coordinates));
            }
        }

        public Coordinates Position { get; private set; }

        public int Priority { get; private set; }

        public IDictionary<Coordinates, char> Content { get; private set; }
        public bool ShouldBeDrawn(int screenTop, int screenBottom)
        {
            // f u draw me 
            return true;
        }

        private void RecreateFences()
        {
            Content.Clear();
            for (int i = 0; i < mapFences.Length; i++)
            {
                var fenceXCoordinate = i == 0 ? 0 : Globals.X_MAX_BOARD_SIZE - 1;
                for (int j = 0; j < mapFences[i].Length; j++)
                {
                    var fenceYCoordinate = (physicsEngine.CurrentPosition + j) % Globals.Y_MAX_BOARD_SIZE;
                    Content.Add(new Coordinates(fenceXCoordinate, fenceYCoordinate), mapFences[i][j]);
                }

            }
        }

        public override void Move()
        {
            CurrentTick++;
            if (CurrentTick == 0)
            {
                RecreateFences();
                Ui.Instance().RequireScreenUpdate();
            }
        }
    }
}
