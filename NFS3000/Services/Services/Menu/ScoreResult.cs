using System;
using System.Collections.Generic;
using Services.ServicesContracts.MeniuItems;

namespace Services.Services.Menu
{
    public class ScoreResult : Button
    {
        private readonly List<Button> menu;

        public ScoreResult(List<Button> menu, string highScorrer) : base(menu, highScorrer)
        {
            this.menu = menu;
        }

        public override List<Button> Action()
        {
            return menu;
        }

        public override void Action(ConsoleKey key)
        {
        }
    }
}
