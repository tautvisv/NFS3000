using System;
using System.Collections.Generic;
using Services.Services.Objects;
using Services.Services.Objects.Singletons;
using Services.ServicesContracts.MeniuItems;

namespace Services.Services.Menu
{
    public class StartButton : Button
    {
        private readonly List<Button> fatherButtons;

        public StartButton(List<Button> fatherButtons) : base(fatherButtons, "Start")
        {
            this.fatherButtons = fatherButtons;
        }

        public override List<Button> Action()
        {
            return new List<Button>{ new ActionButton(fatherButtons) };
        }

        public override void Action(ConsoleKey key)
        {
        }
    }
}
