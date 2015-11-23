using Services.ServicesContracts.Objects;

namespace Services.Services.Objects.Engines
{
    public class Electric : IEngine
    {
        private const char Engine = '+';
        public void Upgrade(ICar car)
        {
            var coordinates = new Coordinates(1, 2);
            if (car.Content.ContainsKey(coordinates))
            {
                car.Content[coordinates] = Engine;
            }
            else
            {
                car.Content.Add(coordinates, Engine);
            }
        }
    }
}
