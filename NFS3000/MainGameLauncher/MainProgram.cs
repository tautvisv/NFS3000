
using Services.Services.Objects.Singletons;
using Services.ServicesContracts;

namespace MainGameLauncher
{
    class MainProgram
    {
        public static IUI UISingleton;
        static void Main(string[] args)
        {
            UISingleton.Draw();
        }
    }
}
