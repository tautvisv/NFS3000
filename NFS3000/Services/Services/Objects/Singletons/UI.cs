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
        private static readonly object LockInstanceObj = new object();

        public static Ui Instance()
        {
            if (instance == null)
            {
                lock (LockInstanceObj)
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
            UpdateScreen = true;
            for (var y = 0; y < Globals.Y_MAX_BOARD_SIZE; ++y)
            {
                view[y] = new char[Globals.X_MAX_BOARD_SIZE];
            }
            ClearView();
        }

        [STAThread]
        public void Draw(TextBox mainBox)
        {
            if (!UpdateScreen)
            {
                return;
            }
            lock (mainBox)
            {
                ClearView();
                foreach (var drawable in drawables)
                {
                    foreach (var pixel in drawable.Content)
                    {
                        view[drawable.Position.Y + pixel.Key.Y][drawable.Position.X + pixel.Key.X] = pixel.Value;
                    }
                }

                var sb = new StringBuilder();
                foreach (var line in view)
                {
                    sb.AppendLine(new string(line));
                }
                mainBox.Text = sb.ToString();
                UpdateScreen = false;
            }
        }
        /// <summary>
        /// Piešia konsolėj
        /// </summary>
        [STAThread]
        public void Draw()
        {
            if (!UpdateScreen)
            {
                return;
            }
            ClearView();

            foreach (var drawable in drawables)
            {
                foreach (var pixel in drawable.Content)
                {
                    view[drawable.Position.Y + pixel.Key.Y][drawable.Position.X + pixel.Key.X] = pixel.Value;
                }
            }

            var sb = new StringBuilder();
            foreach (var line in view)
            {
                sb.AppendLine(new string(line));
            }
            Console.Write(sb.ToString());
            Console.SetCursorPosition(0, 0);
            UpdateScreen = false;

        }

        public void AddDrawableItem(IDrawable drawable)
        {
            drawables.Add(drawable);
            drawables = drawables.OrderBy(t => t.Priority).ToList();
        }

        public void RequireScreenUpdate()
        {
            UpdateScreen = true;
        }

        private void ClearView()
        {
            for (int y = 0; y < Globals.Y_MAX_BOARD_SIZE; ++y)
                for (int x = 0; x < Globals.X_MAX_BOARD_SIZE; ++x)
                    view[y][x] = Globals.BACKGROUND_DEFAULT_VALUE;

            //for (int i = 0; i < Globals.Y_MAX_BOARD_SIZE; i++)
            //{
            //    view[i] = new char[Globals.X_MAX_BOARD_SIZE];
            //    for (int j = 0; j < Globals.X_MAX_BOARD_SIZE; j++)
            //    {
            //        view[i][j] = Globals.BACKGROUND_DEFAULT_VALUE;
            //    }
            //}
        }

        private bool UpdateScreen { get; set; }
    }
}
