using System;
using System.Collections.Generic;
using System.IO;

using Data;

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
                string[] allLines;
                try
                {
                    allLines = System.IO.File.ReadAllLines(Globals.MODELS_PATH + file);
                }
                catch (DirectoryNotFoundException e)
                {
                    throw new Exception("Failed to open models directory!", e);
                }
                catch (FileNotFoundException e)
                {
                    throw new Exception(string.Format("Could not found model file: '{0}' in '{1}'.", file, Globals.MODELS_PATH), e);
                }
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
