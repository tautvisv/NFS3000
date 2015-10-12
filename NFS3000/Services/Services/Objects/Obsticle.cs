using System.Collections.Generic;
using System.Linq;

using Services.Services.Objects.Singletons;
using Services.ServicesContracts.Objects;

namespace Services.Services.Objects
{
    public class Obsticle : IObsticle
    {
        public Coordinates Position { get; private set; }
        public int Priority { get; private set; }
        public IDictionary<Coordinates, char> Content { get; private set; }
        public bool ShouldBeDrawn(int screenTop, int screenBottom)
        {
            return Position.Y >= screenTop + Length && Position.Y < screenBottom;
        }

        public Obsticle()
        {
            Content = ModelLoader.Instance().LoadModel("Obsticle");
            Width = Content.Max(t => t.Key.X) - Content.Min(t => t.Key.X);
            Length = Content.Max(t => t.Key.Y) - Content.Min(t => t.Key.Y);
        }

        private int Width { get; set; }

        private int Length { get; set; }

        public IItem Collect()
        {
            throw new System.NotImplementedException();
        }

        public void Move()
        {
            throw new System.NotImplementedException();
        }
    }
}
