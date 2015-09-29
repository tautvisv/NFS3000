using Data;
using Services.Services.Objects.Singletons;

namespace Services.Services.Objects
{
    public class RivalCar:Car
    {
        public RivalCar()
        {
            Content = ModelLoader.Instance().LoadModel("CarRival" + Globals.MODELS_FILES_EXTENSION);
            Priority = 99;
        }
    }
}
