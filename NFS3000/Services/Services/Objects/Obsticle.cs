using System.Collections.Generic;
using System.Linq;
using Data;
using Services.Services.Objects.Singletons;
using Services.ServicesContracts.Objects;

namespace Services.Services.Objects
{
    public class Obsticle : AIObject, IObsticle
    {
        public Coordinates Position { get; private set; }
        public int Priority { get; private set; }
        public IDictionary<Coordinates, char> Content { get; private set; }
        public bool ShouldBeDrawn(int screenTop, int screenBottom)
        {
            return Position.X + Width < Globals.X_MAX_BOARD_SIZE
                && Position.Y >= screenTop + Length && Position.Y < screenBottom-1;
        }

        public Obsticle()
        {
            RequeredTicksToMove = 5;
            Content = ModelLoader.Instance().LoadModel(ModelsNames.Obsticles);
            Width = Content.Max(t => t.Key.X) - Content.Min(t => t.Key.X);
            Length = Content.Max(t => t.Key.Y) - Content.Min(t => t.Key.Y);
            Position = new Coordinates(15, 0);
        }

        private int Width { get; set; }

        private int Length { get; set; }

        public IItem Collect()
        {
            throw new System.NotImplementedException();
        }

        public override void Move()
        {
            if (PhysicsEngine.Instance().CurrentPosition%RequeredTicksToMove == 0)
            {
                Position.Y++;
                Ui.Instance().RequireScreenUpdate();
            }
        }
    }
}
