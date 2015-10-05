using Services.Services.Objects;

namespace Services.ServicesContracts.Objects
{
    public interface IMovable
    {
        Coordinates Position { get; }

        void MoveLeft();
        void MoveRight();
        void MoveUp();
        void MoveDown();
    }
}
