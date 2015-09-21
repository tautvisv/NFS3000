using Services.ServicesContracts.Objects;

namespace Services.ServicesContracts
{
    interface IScoreCounter
    {
        void AddPlayer(IPlayer player);
        int GetScore(IPlayer player);
        int UpdateScore(IIncrementScore thisEvent, IPlayer player);
        void ResetScores();
    }
}