using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Services.ServicesContracts.Objects;

namespace Services.Services.Objects.Singletons
{
    public sealed class PhysicsEngine
    {
        private static PhysicsEngine instance;
        private static readonly object LockInstanceObj = new object();
        private readonly IList<AIObject> AiObjects; 
        public int CurrentPosition { get; private set; }
        private Random Rand { get; set; }

        private PhysicsEngine()
        {
            Rand = new Random(16);
            AiObjects = new List<AIObject>();
        }

        public static PhysicsEngine Instance()
        {
            if (instance == null)
            {
                lock (LockInstanceObj)
                {
                    if (instance == null)
                    {
                        instance = new PhysicsEngine();
                    }
                }
            }
            return instance;
        }

        public void CalculateLogic()
        {
            var player = ScoreCounter.Instance().GetPlayer();
            CurrentPosition++;
            if (CurrentPosition % 10 == 0)
            {
                var newObsticle = new Obsticle();
                newObsticle.Position.X = Rand.Next(Globals.X_MAX_BOARD_SIZE-1);
                Ui.Instance().AddDrawableItem(newObsticle);
                AddItem(newObsticle);
            }
            var carPozition = player != null ? ((ILocation)player.Car) : null;
            foreach (var aiObject in AiObjects)
            {
                if (aiObject is IObsticle && carPozition != null)
                {
                    var obsticle = (IObsticle) aiObject;
                    if (obsticle.Position.X-2 <= carPozition.Position.X && obsticle.Position.X + 2 >= carPozition.Position.X
                        && obsticle.Position.Y - 2 <= carPozition.Position.Y && obsticle.Position.Y + 1 >= carPozition.Position.Y)
                    {
                        if (Console.BackgroundColor == ConsoleColor.White)
                        {
                            ScoreCounter.Instance().GetHighScores();
                        }
                        Console.BackgroundColor = Console.BackgroundColor == ConsoleColor.Blue ? ConsoleColor.Red : ConsoleColor.Blue;
                    }
                    else if (Console.BackgroundColor == ConsoleColor.White)
                    {
                        ScoreCounter.Instance().UpdateScore(player.Car, player);
                    }
                }
                aiObject.Move();
            }
        }

        public void AddItem(AIObject o)
        {
            AiObjects.Add(o);
        }

        public void RemoveItem(AIObject o)
        {
            AiObjects.Remove(o);
        }
    }
}
