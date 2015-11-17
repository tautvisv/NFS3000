using System;
using System.Threading;
using Data;
using Services.Services.Objects;
using Services.Services.Objects.Factories;
using Services.Services.Objects.Singletons;
using Services.ServicesContracts.Objects;

namespace GameConsole
{
    internal class GameLauncher
    {
        Thread paintThread;
        private Player player1;
        private Player player2;

        static void Main(string[] args)
        {
            var game = new GameLauncher();
            game.Initialise();
            game.StartGame();
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
                    ChangePlayerDirection(key, player1);
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
            var car1 = new Car();
            var car2 = new Car();
            player2 = new Player { Car = car2 };
            player1 = new Player { Car = car1 };
            car1.SetCarNumber(1);
            car2.SetCarNumber(2);
            player1.Car = car1;
            player2.Car = car2;
            Ui.Instance().AddDrawableItem(car2);
            Ui.Instance().AddDrawableItem(car1);
            var map = new Map(new CarFactory(), new ObsticlesFactory());
            Ui.Instance().AddDrawableItem(map);
            paintThread = new Thread(() =>
            {
                while (true)
                {
                    Ui.Instance().Draw();
                    //Reikia physics engine Object
                    map.Move();
                    Thread.Sleep(Globals.REFRESH_RATE);
                }
            });
            paintThread.Start(); 
        }
    }
}
