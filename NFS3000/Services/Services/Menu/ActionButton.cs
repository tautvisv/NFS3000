using System;
using System.Collections.Generic;
using Services.Services.Objects;
using Services.Services.Objects.Singletons;
using Services.ServicesContracts.MeniuItems;

namespace Services.Services.Menu
{
    public class ActionButton : Button
    {
        private readonly List<Button> fatherButtons;
        private Player player;

        public ActionButton(List<Button> fatherButtons) : base(fatherButtons, "", false)
        {
            this.fatherButtons = fatherButtons;
            player = new Player{Name = "Player1"};
            player.Car = new Car();
            Ui.Instance().AddDrawableItem(player.Car);
            ScoreCounter.Instance().AddPlayer(player);
            Ui.Instance().ClearObsticles();
        }

        public override List<Button> Action()
        {
            ScoreCounter.Instance().RemovePlayer(player);
            Ui.Instance().RemoveDrawableItem(player.Car);
            return fatherButtons;
        }

        public override void Action(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    player.Car.MoveUp();
                    break;
                case ConsoleKey.LeftArrow:
                    player.Car.MoveLeft();
                    break;
                case ConsoleKey.RightArrow:
                    player.Car.MoveRight();
                    break;
                case ConsoleKey.DownArrow:
                    player.Car.MoveDown();
                    break;
                default:
                    return;
            }
        }
    }
}
