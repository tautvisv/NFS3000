using System;
using Services.Services.Objects;
using System.Collections.Generic;
using Services.ServicesContracts.Objects;

namespace Services.ServicesContracts
{
    /// <summary>
    /// IDisposable will handle high score write to file
    /// </summary>
    public interface IScoreCounter : IDisposable
    {
        void AddPlayer(IPlayer player);
        int GetScore(IPlayer player);
        IList<HighScoreItem> GetHighScores();
        int UpdateScore(IIncrementScore thisEvent, IPlayer player);
        void ResetScores();
        int GetPlayerCount();
    }
}