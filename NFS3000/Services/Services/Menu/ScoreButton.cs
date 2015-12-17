using System;
using System.Collections.Generic;
using Services.Services.Objects;
using Services.Services.Objects.Singletons;
using Services.ServicesContracts.MeniuItems;

namespace Services.Services.Menu
{
    public class ScoreButton : Button
    {
        private readonly List<Button> fatherButtons;

        public ScoreButton(List<Button> fatherButtons) : base(fatherButtons, "Scores")
        {
            this.fatherButtons = fatherButtons;
        }

        public override List<Button> Action()
        {
            
            var list = new List<Button>();
            Coordinates lastButtonCoordinates = new Coordinates(10, 3);
            foreach (var score in ScoreCounter.Instance().GetHighScores())
            {
                var item = new ScoreResult(fatherButtons, score.Name + ": " + score.Score) { Position = lastButtonCoordinates + new Coordinates() };
                list.Add(item);
                lastButtonCoordinates.Y += 2;
            }
            return list;
        }

        public override void Action(ConsoleKey key)
        {
        }
    }
}
