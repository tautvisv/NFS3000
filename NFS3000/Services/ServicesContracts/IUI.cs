using Services.ServicesContracts.Objects;

namespace Services.ServicesContracts
{
    ///<summary>This will draw EVERYTHING!!!</summary>
    // ReSharper disable once InconsistentNaming
    interface IUI
    {
        void Draw();
        void AddDrawableItem(IDrawable drawable);
    }
}
