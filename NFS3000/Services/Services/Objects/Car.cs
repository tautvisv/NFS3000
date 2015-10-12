using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Data;
using Services.Services.Objects.Singletons;
using Services.ServicesContracts.Objects;

namespace Services.Services.Objects
{
    public class Car : ICar
    {
        public Car()
        {
            Content = ModelLoader.Instance().LoadModel("Car");
            Priority = 100;
            Position = new Coordinates(10, 10);
            Width = Content.Max(t => t.Key.X) - Content.Min(t => t.Key.X);
            Length = Content.Max(t => t.Key.Y) - Content.Min(t => t.Key.Y);
        }

        private int Width { get; set; }
        private int Length { get; set; }

        public Coordinates Position { get; protected set; }
        public int Priority { get; protected set; }

        public IDictionary<Coordinates, char> Content { get; protected set; }
        public bool ShouldBeDrawn(int screenTop, int screenBottom)
        {
            return Position.Y >= screenTop && Position.Y < screenBottom + Length;
        }

        public string Name { get; set; }

        public Engine Engine { get; set; }

        public Body Body { get; set; }

        public Tire Tires { get; set; }

        public IUsable Usable { get; set; }

        public void SetCarNumber(int number)
        {
            char numberChar = number.ToString(CultureInfo.InvariantCulture).FirstOrDefault();
            var coordinates = new Coordinates(1, 3);
            if (Content.ContainsKey(coordinates))
            {
                Content[coordinates] = numberChar;
            }
            else
            {
                Content.Add(coordinates, numberChar);
            }
        }

        public void MoveLeft()
        {
            //TODO some boom logic
            if(Position.X == 0)
                return;
            Position.X -= 1;
        }

        public void MoveRight()
        {
            //TODO some boom logic
            if (Position.X > Globals.X_MAX_BOARD_SIZE-Width-2)
                return;
            Position.X += 1;
        }

        public void MoveUp()
        {
            //TODO some boom logic
            if (Position.Y == 0)
                return;
            Position.Y -= 1;
        }

        public void MoveDown()
        {
            //TODO some boom logic
            if (Position.Y == Globals.Y_MAX_BOARD_SIZE-Length-1)
                return;
            Position.Y += 1;
        }
    }
}
