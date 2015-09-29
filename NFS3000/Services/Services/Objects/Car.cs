using System.Collections.Generic;
using System.Linq;
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
            Position =  new Coordinates(10, 10);
        }

        public Coordinates Position { get; protected set; }
        public int Priority { get; protected set; }

        public IDictionary<Coordinates, char> Content { get; protected set; }

        public string Name { get; set; }

        public Engine Engine { get; set; }

        public Body Body { get; set; }

        public Tire Tires { get; set; }

        public IUsable Usable { get; set; }

        public void SetCarNumber(int number)
        {
            char numberChar = number.ToString().FirstOrDefault();
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
    }
}
