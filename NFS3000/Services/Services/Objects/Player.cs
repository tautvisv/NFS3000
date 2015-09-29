using Services.ServicesContracts.Objects;

namespace Services.Services.Objects
{
    public class Player : IPlayer
    {
        public string Name { get; set; }

        public ICar Car { get; set; }
    }
}
