using System.Collections.Generic;

using Services.ServicesContracts;

namespace Services.Services.Objects.Singletons
{
    public class ModelLoader : IModelLoader
    {
        private static ModelLoader instance;
        private static object lockInstanceObj = new object();

        public static ModelLoader Instance()
        {
            if (instance == null)
            {
                lock (lockInstanceObj)
                {
                    if (instance == null)
                    {
                        instance = new ModelLoader();
                    }
                }
            }
            return instance;
        }

        private ModelLoader()
        {
        }

        public IDictionary<Coordinates, char> LoadModel(string file)
        {
            lock (lockInstanceObj)
            {
                var model = new Dictionary<Coordinates, char>();
                var allLines = System.IO.File.ReadAllLines(file);
                for (int lineNumber = 0; lineNumber < allLines.Length; lineNumber++)
                {
                    for (int lineCharNumber = 0; lineCharNumber < allLines[lineNumber].Length; lineCharNumber++)
                    {
                        if (allLines[lineNumber][lineCharNumber] != ' ')
                        {
                            model.Add(new Coordinates(lineCharNumber, lineNumber), allLines[lineNumber][lineCharNumber]);
                        }
                    }
                }
                return model;
            }
        }
    }
}
