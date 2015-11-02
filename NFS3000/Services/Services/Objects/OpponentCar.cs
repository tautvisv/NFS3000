using System;
using System.Collections.Generic;
using Services.ServicesContracts.Objects;

namespace Services.Services.Objects
{
    public class OpponentCar:ICar
    {
        Coordinates ILocation.Position
        {
            get { throw new NotImplementedException(); }
        }

        public void MoveLeft()
        {
            throw new NotImplementedException();
        }

        public void MoveRight()
        {
            throw new NotImplementedException();
        }

        public void MoveUp()
        {
            throw new NotImplementedException();
        }

        public void MoveDown()
        {
            throw new NotImplementedException();
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

        Coordinates IDrawable.Position
        {
            get { throw new NotImplementedException(); }
        }

        Coordinates IMovable.Position
        {
            get { throw new NotImplementedException(); }
        }

        public string Name
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public IItem Engine
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public IItem Body
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public IItem Tires
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public IUsable Usable
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public void SetCarNumber(int number)
        {
            throw new NotImplementedException();
        }
    }
}
