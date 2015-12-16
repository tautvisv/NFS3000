using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Data;
using Services.Services.Objects;
using Services.Services.Objects.Singletons;
using Services.ServicesContracts.Objects;

namespace Services.ServicesContracts.MeniuItems
{
    public abstract class Button : IDrawable
    {
        public Button(List<Button> fatherButtons, string name, bool highlight = true)
        {
            Highlight = highlight ? ModelLoader.Instance().LoadModel(ModelsNames.ButtonHighlight) : new Dictionary<Coordinates, char>();
            ContentText = ModelLoader.Instance().TextToModel(name);
        }

        private IDictionary<Coordinates, char> ContentText { get; set; }

        public Coordinates Position { get; set; }

        public int Priority
        {
            get { return 1010; }
        }

        public IDictionary<Coordinates, char> Content {
            get
            {
                return IsSelected ? Highlight.Union(ContentText).ToDictionary(t => t.Key + Position, t => t.Value) : ContentText.ToDictionary(t => t.Key + Position, t => t.Value);
            }
        }

        private IDictionary<Coordinates, char> Highlight { get; set; }

        public bool ShouldBeDrawn(int screenTop, int screenBottom)
        {
            return true;
        }

        public bool IsSelected { get; set; }

        public abstract List<Button> Action();

        public abstract void Action(ConsoleKey key);
    }
}
