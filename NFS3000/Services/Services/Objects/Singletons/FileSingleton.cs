using System;
using System.IO;

namespace Services.Services.Objects.Singletons
{
    
    public class FileSingleton:IDisposable
    {
        private StreamWriter file;
        private static FileSingleton instance;
        private static object lockInstanceObj = new object();

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

        public void Write(string text)
        {
            file.Write(text);
        }
        private FileSingleton()
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
    }
}
