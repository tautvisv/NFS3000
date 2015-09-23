using System;
using Services.Services.Objects.Singletons;
namespace MainGameLauncher
{
    public class MainProgram
    {
        static void Main(string[] args)
        {
            var UISingleton = UI.Instance();
            UISingleton.Draw();
            var myFile = FileSingleton.Instance();
            myFile.Write("veikia!!!!!!");
            myFile.Dispose();
            Console.ReadKey();
        }
    }
}
