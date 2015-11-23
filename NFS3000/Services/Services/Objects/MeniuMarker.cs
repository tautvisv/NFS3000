using System.Collections.Generic;
using Data;
using Services.Services.Objects.Singletons;
using Services.ServicesContracts.Objects;

namespace Services.Services.Objects
{
    public class MeniuMarker : IDrawable
    {
        public MeniuMarker()
        {
            Position = new Coordinates();
            Content = ModelLoader.Instance().LoadModel(ModelsNames.MeniuMarker);
        }

        public Coordinates Position { get; private set; }

        public int Priority
        {
            get { return 1001; }
        }

        public IDictionary<Coordinates, char> content { get; set; }

        public IDictionary<Coordinates, char> Content
        {
            get { return content; }
            set { content = value; }
        }

        public bool ShouldBeDrawn(int screenTop, int screenBottom)
        {
            return true;
        }
    }
}
