using System.Windows.Forms;

using Services.ServicesContracts.Objects;

namespace Services.ServicesContracts
{
    ///<summary>This will draw EVERYTHING!!!</summary>
    public interface IPaint
    {
        void Draw(TextBox textBox);
        void AddDrawableItem(IDrawable drawable);
        void RequireScreenUpdate();
    }
}
