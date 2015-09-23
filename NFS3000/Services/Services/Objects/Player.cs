using Services.ServicesContracts.Objects;

namespace Services.Services.Objects
{
    internal class Player : IPlayer
    {
        public string Name { get; set; }

        public ICar Car { get; set; }
    }
}
