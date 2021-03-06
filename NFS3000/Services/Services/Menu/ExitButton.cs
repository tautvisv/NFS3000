﻿using System;
using System.Collections.Generic;
using Services.ServicesContracts.MeniuItems;

namespace Services.Services.Menu
{
    public class ExitButton : Button
    {
        public ExitButton(List<Button> fatherButtons) : base(fatherButtons, "Exit")
        {
        }

        public override List<Button> Action()
        {
            Environment.Exit(0);
            return new List<Button>();
        }

        public override void Action(ConsoleKey key)
        {
        }
    }
}
