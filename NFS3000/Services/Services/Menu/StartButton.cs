using Services.Services.Objects;
using Services.Services.Objects.Singletons;
using Services.ServicesContracts.MeniuItems;

namespace Services.Services.Menu
{
    public class StartButton : Button
    {
        public StartButton() : base("Start")
        {
        }

        public override void Action()
        {
            var map = new Map(PhysicsEngine.Instance());
            Ui.Instance().AddDrawableItem(map);
            var car = new Car();
            Ui.Instance().AddDrawableItem(car);
            PhysicsEngine.Instance().AddItem(car);
        }
    }
}
