using System.Windows.Forms;

using Services.ServicesContracts.Objects;

namespace Services.ServicesContracts
{
    ///<summary>This will draw EVERYTHING!!!</summary>
    public interface IPaint
    {
        void Draw(TextBox textBox);
        void Draw();
        void AddDrawableItem(IDrawable drawable);
        void RemoveDrawableItem(IDrawable drawable);
        void ClearObsticles();
        void RequireScreenUpdate();
    }
}
