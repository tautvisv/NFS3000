using System;
using System.Collections.Generic;
using Services.ServicesContracts.Objects;

namespace Services.Services.Objects
{
    public class Meniu : IDrawable
    {
        private IDrawable Start { get; set; }
        private IDrawable HighScores { get; set; }
        private IDrawable Upgrades { get; set; }
        private IDrawable SetName { get; set; }
        public int Priority
        {
            get { throw new NotImplementedException(); }
        }

        public IDictionary<Coordinates, char> Content
        {
            get { throw new NotImplementedException(); }
        }

        public bool UpdateScreen
        {
            get { throw new NotImplementedException(); }
        }
    }
}
