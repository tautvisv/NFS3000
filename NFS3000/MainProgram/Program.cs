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
            Console.ReadKey();
            var ScoreCounterSingleton = ScoreCounter.Instance();
            ScoreCounterSingleton.ResetScores();
            Console.ReadKey();
        }
    }
}
