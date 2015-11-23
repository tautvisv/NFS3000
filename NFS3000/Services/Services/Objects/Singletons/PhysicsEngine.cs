using System.Collections.Generic;
using Services.ServicesContracts.Objects;

namespace Services.Services.Objects.Singletons
{
    public sealed class PhysicsEngine
    {
        private static PhysicsEngine instance;
        private static readonly object LockInstanceObj = new object();
        private readonly IList<AIObject> AiObjects; 
        public int CurrentPosition { get; private set; }

        private PhysicsEngine()
        {
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
            CurrentPosition++;
            foreach (var aiObject in AiObjects)
            {
                aiObject.Move();
            }
        }

        public void AddItem(AIObject o)
        {
            AiObjects.Add(o);
        }
    }
}
