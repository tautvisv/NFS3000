using System;
using System.Collections.Generic;
using Services.ServicesContracts.MeniuItems;

namespace Services.Services.Menu
{
    public class ActionButton : Button
    {
        private readonly List<Button> fatherButtons;

        public ActionButton(List<Button> fatherButtons) : base(fatherButtons, "", false)
        {
            this.fatherButtons = fatherButtons;
        }

        public override List<Button> Action()
        {
            return fatherButtons;
        }

        public override void Action(ConsoleKey key)
        {
        }
    }
}
