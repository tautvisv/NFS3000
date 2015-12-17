using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public static void SaveHighscore()
        {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter("HighScores.txt"))

                    foreach (var highscore in highScores)
                    {
                        file.WriteLine(highscore.Name + ' ' + highscore.Score);
                    }
        }
        public static void LoadHighscores()
        {
            if (File.Exists("HighScores.txt"))
            {

                string[] lines = System.IO.File.ReadAllLines("HighScores.txt");
                char[] delimiterChars = {' ', ',', '.', ':', '\t'};
                foreach (var line in lines)
                {
                    string[] words = line.Split(delimiterChars);
                    highScores.Add(new HighScoreItem(words[0] + ";" + words[1]));
                }
            }
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

        public void RemovePlayer(IPlayer player)
        {
            Players.Remove(player);
        }

        public int GetScore(IPlayer player)
        {
            return Scores[player];
        }
        public IList<HighScoreItem> GetHighScores()
        {
            var player = GetPlayer();
            highScores.Clear();
            LoadHighscores();
            if (player != null)
            {
                var score = Scores[player];
                highScores.Add(new HighScoreItem(player.Name+";"+score));
                SaveHighscore();
            }
            return highScores.OrderByDescending(t=>t.Score).Take(10).ToList();
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

        public IPlayer GetPlayer()
        {
            return Players.FirstOrDefault();
        }

        public void Dispose()
        {
        }
    }
}