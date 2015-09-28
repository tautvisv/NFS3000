using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Data;

using Services.ServicesContracts;
using Services.ServicesContracts.Objects;

namespace Services.Services.Objects.Singletons
{
    public sealed class Ui : IPaint
    {
        private readonly char[][] view = new char[Globals.Y_MAX_BOARD_SIZE][];
        private IList<IDrawable> drawables;
        private static Ui instance;
        private static object lockInstanceObj = new object();

        public static Ui Instance()
        {
            if (instance == null)
            {
                lock (lockInstanceObj)
                {
                    if (instance == null)
                    {
                        instance = new Ui();
                    }
                }
            }
            return instance;
        }

        private Ui()
        {
            drawables = new List<IDrawable>();
        }

        [STAThread]
        public void Draw(TextBox mainBox)
        {
            ClearView();
            foreach (var drawable in drawables.OrderBy(t=>t.Priority))
            {
                foreach (var pixel in drawable.Content)
                {
                    view[pixel.Key.Y][pixel.Key.X] = pixel.Value;
                }
            }
            mainBox.Clear();
            var sb = new StringBuilder();
            foreach (var line in view)
            {
                sb.AppendLine(new string(line));
            }
            mainBox.Text = sb.ToString();
            Console.WriteLine("I am drawing environment!");
        }

        public void AddDrawableItem(IDrawable drawable)
        {
            drawables.Add(drawable);
        }

        public void RequireScreenUpdate()
        {
            UpdateScreen = true;
        }

        private void ClearView()
        {
            for (int i = 0; i < Globals.Y_MAX_BOARD_SIZE; i++)
            {
                view[i] = new char[Globals.X_MAX_BOARD_SIZE];
                for (int j = 0; j < Globals.X_MAX_BOARD_SIZE; j++)
                {
                    view[i][j] = Globals.BACKGROUND_DEFAULT_VALUE;
                }
            }
        }

        private bool UpdateScreen { get; set; }
    }
}
