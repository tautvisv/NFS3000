using Services.ServicesContracts.Objects;

namespace Services.ServicesContracts
{
    ///<summary>This will draw EVERYTHING!!!</summary>
    public interface IUI
    {
        void Draw();
        void AddDrawableItem(IDrawable drawable);
    }
}
