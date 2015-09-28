using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Services.Services.Objects.Singletons;

namespace Services.Services.Objects
{
    public class RivalCar:Car
    {
        public RivalCar()
        {
            Content = ModelLoader.Instance().LoadModel(Globals.MODELS_PATH + "CarRival" + Globals.MODELS_FILES_EXTENSION);
            Priority = 99;
            GlobalPosition = new Coordinates(20,5);
        }
    }
}
