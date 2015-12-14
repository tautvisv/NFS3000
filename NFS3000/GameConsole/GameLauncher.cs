using System;
using System.Threading;
using Data;
using Microsoft.Practices.Unity;
using Services.Services.Objects;
using Services.Services.Objects.Factories;
using Services.Services.Objects.Singletons;
using Services.ServicesContracts;
using Services.ServicesContracts.Objects;

namespace GameConsole
{
    internal class GameLauncher
    {
        Thread paintThread;
        private Menu menu;

        static void Main(string[] args)
        {
            RegisterElements();
            var game = new GameLauncher();
            game.Initialise();
            game.StartGame();
        }

        public static void RegisterElements()
        {
            var container = new UnityContainer();
            container.RegisterInstance<IModelLoader>(ModelLoader.Instance());
            container.RegisterInstance<PhysicsEngine>(PhysicsEngine.Instance());
            container.RegisterInstance<IScoreCounter>(ScoreCounter.Instance());
            container.RegisterInstance<IPaint>(Ui.Instance());
        }
        public void Initialise()
        {
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            //TODO parinkti protingai aukštį bei plotį
            Console.SetWindowSize(Globals.X_MAX_BOARD_SIZE, Globals.Y_MAX_BOARD_SIZE);
            DoTestStuff();
        }
        public void StartGame()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Escape)
                    {
                        Environment.Exit(0);
                    }
                    menu.Control(key.Key);
                }
                else
                {
                    //Šitas padeda sutaupyti resursus, kad netikrintų visada
                    Thread.Sleep(Globals.REFRESH_RATE);
                }
            }
        }

        public void ChangePlayerDirection(ConsoleKeyInfo key, IPlayer player)
        {
            switch (key.Key)
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
            //TODO Perkelti jaučiu reikia į move funkciją
            Ui.Instance().RequireScreenUpdate();
        }

        public void DoTestStuff()
        {
            menu = new Menu(Ui.Instance());
            Ui.Instance().AddDrawableItem(menu);
            paintThread = new Thread(() =>
            {
                while (true)
                {
                    PhysicsEngine.Instance().CalculateLogic();
                    Ui.Instance().Draw();
                    Thread.Sleep(Globals.REFRESH_RATE);
                }
            });
            paintThread.Start(); 
        }
    }
}
