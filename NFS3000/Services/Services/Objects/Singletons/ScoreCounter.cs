using System;
using System.Collections.Generic;
using Services.ServicesContracts;
using Services.ServicesContracts.Objects;

namespace Services.Services.Objects.Singletons
{
    public sealed class ScoreCounter : IScoreCounter
    {
        private static ScoreCounter instance;
        private static IList<HighScoreItem> highScores = new List<HighScoreItem>();
        private static IDictionary<IPlayer, int> Scores { get; set; }
        private static IList<IPlayer> Players { get; set; }
        private static readonly object lockInstanceObj = new object();

        private ScoreCounter()
        {
            Players = new List<IPlayer>();
            Scores = new Dictionary<IPlayer, int>();
        }

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
            Players.Add(player);
            Scores.Add(player, 0);
        }
        public int GetScore(IPlayer player)
        {
            return Scores[player];
        }
        public IList<HighScoreItem> GetHighScores()
        {
            return highScores;
        }
        public int UpdateScore(IIncrementScore thisEvent, IPlayer player)
        {
            return Scores[player] = thisEvent.IncrementScore(Scores[player]);
        }
        public void ResetScores()
        {
            foreach (var score in Scores)
            {
                Scores[score.Key] = 0;
            }
        }

        public int GetPlayerCount()
        {
            return Players.Count;
        }

        public void Dispose()
        {
        }
    }
}