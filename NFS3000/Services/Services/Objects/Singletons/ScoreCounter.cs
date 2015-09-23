using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.ServicesContracts;
using Services.ServicesContracts.Objects;

namespace Services.Services.Objects.Singletons
{
    public sealed class ScoreCounter : IScoreCounter
    {
        private static ScoreCounter instance;
        private static IList<HighScoreItem> highScores = new List<HighScoreItem>();
        private static object lockInstanceObj = new object();
        

        public static ScoreCounter Instance()
        {
            lock (lockInstanceObj)
            {
                if (instance == null)
                {
                    instance = new ScoreCounter();
                }
            }
            return instance;
        }

        public void AddPlayer(IPlayer player)
        {
            throw new NotImplementedException();
        }
        public int GetScore(IPlayer player)
        {
            throw new NotImplementedException();
            return 0;
        }
        public IList<HighScoreItem> GetHighScores()
        {
            return highScores;
        }
        public int UpdateScore(IIncrementScore thisEvent, IPlayer player)
        {
            throw new NotImplementedException();
            return 0;
        }
        public void ResetScores()
        {
            Console.WriteLine("I am doing something!!!");
            highScores.Clear();
        }

        public void Dispose()
        {
        }
    }
}