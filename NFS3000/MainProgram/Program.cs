using System;
using Services.Services.Objects.Singletons;

namespace MainGameLauncher
{
    public class MainProgram
    {
        static void Main(string[] args)
        {
            var uiSingleton = UI.Instance();
            uiSingleton.Draw();
            var myFile = FileSingleton.Instance();
            myFile.Write("veikia!!!!!!");
            myFile.Dispose();
            Console.ReadKey();
        }
    }
}
