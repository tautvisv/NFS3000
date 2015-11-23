using System;
using Services.ServicesContracts.Objects;

namespace Services.ServicesContracts.Menu
{
    public interface IMenu : IDrawable
    {
        void Control(ConsoleKey key);
    }
}
