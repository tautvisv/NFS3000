using System;
using Services.Services.Objects.Singletons;

namespace MainGameLauncher
{
    public class MainProgram
    {
        public static UI UISingleton;
        static void Main(string[] args)
        {
            UISingleton = UI.Instance();
            UISingleton.Draw();
            UISingleton.Draw();
            Console.ReadKey();
            var ScoreCounterSingleton = ScoreCounter.Instance();
            ScoreCounterSingleton.ResetScores();
            var myFile = FileSingleton.Instance();
            myFile.Write("veikia!!!!!!");
            myFile.Dispose();
            Console.ReadKey();
        }
    }
}
