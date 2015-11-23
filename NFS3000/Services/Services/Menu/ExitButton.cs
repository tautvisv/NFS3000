using System;
using Services.ServicesContracts.MeniuItems;

namespace Services.Services.Menu
{
    public class ExitButton : Button
    {
        public ExitButton() : base("Exit")
        {
        }

        public override void Action()
        {
            Environment.Exit(0);
        }
    }
}
