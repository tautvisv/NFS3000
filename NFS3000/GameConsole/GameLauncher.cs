using System;
using System.Threading;
using Data;
using Microsoft.Practices.Unity;
using Services.Services.Objects;
using Services.Services.Objects.Factories;
using Services.Services.Objects.Singletons;
using Services.ServicesContracts;
using Services.ServicesContracts.Menu;
using Services.ServicesContracts.Objects;

namespace GameConsole
{
    internal class GameLauncher
    {
        Thread paintThread;
        private IMenu menu;
        private readonly IPaint UI;
        private readonly PhysicsEngine Physics;

        static void Main(string[] args)
        {
            RegisterElementsAndStartElements();
        }

        public GameLauncher(IMenu menuItm, IPaint ui, PhysicsEngine PhysicsEng)
        {
            menu = menuItm;
            UI = ui;
            ui.AddDrawableItem(menu);
            Physics = PhysicsEng;
            Initialise();
        }

        public static void RegisterElementsAndStartElements()
        {
            var container = new UnityContainer();
            container.RegisterInstance<IModelLoader>(ModelLoader.Instance());
            container.RegisterInstance<PhysicsEngine>(PhysicsEngine.Instance());
            container.RegisterInstance<IScoreCounter>(ScoreCounter.Instance());
            container.RegisterInstance<IPaint>(Ui.Instance());
            container.RegisterType<IMenu, Menu>();
            container.RegisterType<GameLauncher>();
            var launcer = container.Resolve<GameLauncher>();
            launcer.StartGame();
        }
        public void Initialise()
        {
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            //TODO parinkti protingai aukštį bei plotį
            Console.SetWindowSize(Globals.X_MAX_BOARD_SIZE, Globals.Y_MAX_BOARD_SIZE);
        }
        public void StartGame()
        {
            paintThread = new Thread(() =>
            {
                var fenceLeft = new Fence(0, 2);
                var fenceCenter = new Fence(Globals.X_MAX_BOARD_SIZE/2, 1);
                var fenceRight = new Fence(Globals.X_MAX_BOARD_SIZE-2,2);
                UI.AddDrawableItem(fenceLeft);
                Physics.AddItem(fenceLeft);
                UI.AddDrawableItem(fenceCenter);
                Physics.AddItem(fenceCenter);
                UI.AddDrawableItem(fenceRight);
                Physics.AddItem(fenceRight);
                while (true)
                {
                    Physics.CalculateLogic();
                    UI.Draw();
                    Thread.Sleep(Globals.REFRESH_RATE);
                }
            });
            paintThread.Start(); 

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

    }
}
