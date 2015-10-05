using System;
using System.Collections.Generic;
using System.IO;

using Data;

using Newtonsoft.Json;

using Services.Services.Objects;

namespace MapGenerator
{
    [Serializable]
    public class MapObjects
    {
        public MapObjects(string classType)
        {
            ClassType = classType;
            Positions = new List<Coordinates>();
        }

        public readonly string ClassType;
        public IList<Coordinates> Positions { get; private set; }
    }

    [Serializable]
    public class MapGenerator
    {
        public MapGenerator()
        {
            map = new List<MapObjects>();
        }

        public int MapLength { get; set; }
        public int MapWidth { get; set; }
        public IList<MapObjects> map;

        static void Main(string[] args)
        {
            var mapGenerator = new MapGenerator();
            mapGenerator.CreateMap();
            Console.ReadKey();
        }

        private void CreateMap()
        {
            MapLength = GetIntFromConsole("Please enter map length: ");
            MapWidth = GetIntFromConsole("Please enter map width: ");
            var random = new Random();
            var obsticle = new Obsticle();
            var obsticles = new MapObjects(obsticle.GetType().ToString());
            for (int i = 0; i < MapLength; i+= random.Next(0, 12))
            {
                obsticles.Positions.Add(new Coordinates(random.Next(1, MapWidth - 4), i));
            }
            map.Add(obsticles);
            var modelFileName = GetModelFileName();
            var json = JsonConvert.SerializeObject(this, Formatting.Indented);
            Console.WriteLine("Object: {0}", json);
            File.WriteAllText(modelFileName, json);
            Console.WriteLine("Map created: {0}", modelFileName);
        }

        private int GetIntFromConsole(string message)
        {
            int integer;
            Console.Write(message);
            while (!Int32.TryParse(Console.ReadLine(), out integer))
            {
                Console.Write(message);
            }
            return integer;
        }

        private string GetModelFileName()
        {
            const string message = "Please enter map model name: ";
            Console.Write(message);
            try
            {
                Directory.CreateDirectory(Globals.MODELS_PATH);
            }
            catch (Exception)
            {
            }
            var modelFileName = string.Format("{0}{1}{2}", Globals.MODELS_PATH, Console.ReadLine(), Globals.MODELS_FILES_EXTENSION);
            while (File.Exists(modelFileName))
            {
                Console.Write("Try again file exists '{0}': ", modelFileName);
                modelFileName = string.Format("{0}{1}{2}", Globals.MODELS_PATH, Console.ReadLine(), Globals.MODELS_FILES_EXTENSION);
            }
            return modelFileName;
        }
    }
}
