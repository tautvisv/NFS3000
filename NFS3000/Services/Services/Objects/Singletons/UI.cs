using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.ServicesContracts;
using Services.ServicesContracts.Objects;

namespace Services.Services.Objects.Singletons
{
    public sealed class UI : IUI
    {
        private IList<IDrawable> drawables;
        private static UI instance;
        private static object lockInstanceObj = new object();

        public static UI Instance()
        {
                lock (lockInstanceObj)
                {
                    if (instance == null)
                    {
                        instance = new UI();
                    }
                }
                return instance;
        }

        private UI()
        {
            drawables = new List<IDrawable>();
        }
        public void Draw()
        {
            Console.WriteLine("I am drawing enviroment!!!");
        }

        public void AddDrawableItem(IDrawable drawable)
        {
            drawables.Add(drawable);
        }
    }
}
