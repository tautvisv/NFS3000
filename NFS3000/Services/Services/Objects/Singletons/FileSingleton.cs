﻿using System;
using System.IO;
using Services.ServicesContracts;

namespace Services.Services.Objects.Singletons
{
    public class FileSingleton : IDisposable, IDataWriter
    {
        private StreamWriter file;

        private static FileSingleton instance;
        private static readonly object lockInstanceObj = new object();

        public static FileSingleton Instance()
        {
            lock (lockInstanceObj)
            {
                if (instance == null)
                {
                    instance = new FileSingleton();
                }
            }
            return instance;
        }
        protected FileSingleton()
        {
            file = new StreamWriter("HighScores.txt");
        }
        public void Close()
        {

            file.Flush();
            file.Close();
        }

        public void Dispose()
        {
            file.Flush();
            file.Close();
        }

        public void Write(object obj)
        {
            file.Write(obj);
        }

        public string[] Read()
        {
            return File.ReadAllLines("HighScores.txt");
        }

    }
}
