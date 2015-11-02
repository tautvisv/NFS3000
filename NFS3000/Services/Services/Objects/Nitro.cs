using Services.ServicesContracts.Objects;
using System;
using System.Collections.Generic;

namespace Services.Services.Objects
{
    public class Nitro : IItem, IDrawable
    {
        public void Upgrade()
        {
            throw new NotImplementedException();
        }

        public Coordinates Position
        {
            get { throw new NotImplementedException(); }
        }

        public int Priority
        {
            get { throw new NotImplementedException(); }
        }

        public IDictionary<Coordinates, char> Content
        {
            get { throw new NotImplementedException(); }
        }

        public bool ShouldBeDrawn(int screenTop, int screenBottom)
        {
            throw new NotImplementedException();
        }
    }
}
