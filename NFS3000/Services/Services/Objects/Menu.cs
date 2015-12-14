using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Services.Services.Menu;
using Services.Services.Objects.Singletons;
using Services.ServicesContracts;
using Services.ServicesContracts.MeniuItems;
using Services.ServicesContracts.Menu;
using Services.ServicesContracts.Objects;

namespace Services.Services.Objects
{
    public class Menu : IMenu
    {
        private readonly IPaint painter;
        public Menu(IPaint ui)
        {
            var position = 0;
            painter = ui;
            Position = new Coordinates();
            MenuButtons = new List<Button>();
            MenuButtons.Add(new StartButton(MenuButtons) {Position = new Coordinates(10, position += 3)});
            MenuButtons.Add(new ScoreButton(MenuButtons) {Position = new Coordinates(10, position += 3)});
            MenuButtons.Add(new ExitButton(MenuButtons) {Position = new Coordinates(10, position += 3)});
            MenuButtons[SelectedButton].IsSelected = true;
            painter.RequireScreenUpdate();
        }

        private int selectedButton { get; set; }

        private int SelectedButton {
            get { return selectedButton; }
            set { selectedButton = value < 0 ? MenuButtons.Count-1 : value % MenuButtons.Count; }
        }
        private List<Button> MenuButtons { get; set; }
        private IDrawable Start { get; set; }
        private IDrawable HighScores { get; set; }
        private IDrawable Upgrades { get; set; }
        private IDrawable SetName { get; set; }
        private IDrawable Map { get; set; }
        public Coordinates Position { get; private set; }

        public int Priority
        {
            get { return 1000; }
        }

        public IDictionary<Coordinates, char> Content
        {
            get
            {
                var con = new Dictionary<Coordinates, char>();
                foreach (var button in MenuButtons)
                {
                    con = con.Union(button.Content).ToDictionary(t => t.Key, t => t.Value);
                }
                return con;
            }
        }

        public bool ShouldBeDrawn(int screenTop, int screenBottom)
        {
            return true;
        }

        public void Control(ConsoleKey key)
        {
            MenuButtons[SelectedButton].Action(key);
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    SelectedButton--;
                    break;
                case ConsoleKey.DownArrow:
                    SelectedButton++;
                    break;
                case ConsoleKey.Enter:
                    var menu = MenuButtons[SelectedButton].Action();
                    if (menu.Count > 0)
                        MenuButtons = menu;
                    break;
            }
            foreach (var button in MenuButtons)
            {
                button.IsSelected = false;
            }
            MenuButtons[SelectedButton].IsSelected = true;
            painter.RequireScreenUpdate();
        }
    }
}
