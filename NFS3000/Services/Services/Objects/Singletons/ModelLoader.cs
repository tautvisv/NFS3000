﻿using System;
using System.Collections.Generic;
using System.IO;

using Data;

using Services.ServicesContracts;

namespace Services.Services.Objects.Singletons
{
    public class ModelLoader : IModelLoader
    {
        private static IDictionary<string, IDictionary<Coordinates, char>> flyweightCache { get; set; }
        private static ModelLoader instance;
        private static readonly object lockInstanceObj = new object();

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
            flyweightCache = new Dictionary<string, IDictionary<Coordinates, char>>();
        }

        public IDictionary<Coordinates, char> LoadModel(string modelFileName)
        {
            lock (lockInstanceObj)
            {
                if (flyweightCache.ContainsKey(modelFileName))
                {
                    return flyweightCache[modelFileName];
                }
                var model = new Dictionary<Coordinates, char>();
                string[] allLines;
                try
                {
                    allLines = File.ReadAllLines(string.Format("{0}{1}{2}", Globals.MODELS_PATH, modelFileName, Globals.MODELS_FILES_EXTENSION));
                }
                catch (DirectoryNotFoundException e)
                {
                    throw new Exception("Failed to open models directory!", e);
                }
                catch (FileNotFoundException e)
                {
                    throw new Exception(string.Format("Could not found model text: '{0}' in '{1}'.", modelFileName, Globals.MODELS_PATH), e);
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
                flyweightCache.Add(modelFileName, model);
                return model;
            }
        }

        public IDictionary<Coordinates, char> TextToModel(string text)
        {
            lock (lockInstanceObj)
            {
                if (flyweightCache.ContainsKey(text))
                {
                    return flyweightCache[text];
                }
                var model = new Dictionary<Coordinates, char>();
                string[] allLines = new []{ "", "  " + text };
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
                flyweightCache.Add(text, model);
                return model;
            }
        }
    }
}
