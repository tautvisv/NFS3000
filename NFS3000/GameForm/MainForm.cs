using System;
using System.Threading;
using System.Windows.Forms;

using Data;

using Services.Services.Objects;
using Services.Services.Objects.Singletons;
using Services.ServicesContracts.Objects;

namespace GameForm
{
    public partial class MainForm : Form
    {
        Thread paintThread;
        private Player player1;
        private Player player2;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Name = Globals.PROGRAM_NAME;
            Control.CheckForIllegalCrossThreadCalls = false;

            var car1 = new Car();
            var car2 = new Car();
            player2 = new Player { Car = car2 };
            player1 = new Player { Car = car1 };
            car1.SetCarNumber(1);
            car2.SetCarNumber(2);
            player1.Car = car1;
            player2.Car = car2;
            Ui.Instance().AddDrawableItem(car2);
            Ui.Instance().AddDrawableItem(car1);
            paintThread = new Thread(() =>
            {
                while (true)
                {
                    Ui.Instance().Draw(MainBox);
                    Thread.Sleep(Globals.REFRESH_RATE);
                }
            });
            paintThread.Start();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            paintThread.Abort();
        }

        private void MainForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                this.Close();
            }
            FirstTypeControls(player1, e);
            SecondTypeControls(player2, e);
        }

        private static void FirstTypeControls(IPlayer player, PreviewKeyDownEventArgs e)
        {
            if (player == null)
            {
                return;
            }
            Ui.Instance().RequireScreenUpdate();
            switch (e.KeyData)
            {
                case Keys.Up:
                    ((IMoveable)player.Car).MoveUp();
                    return;
                case Keys.Left:
                    ((IMoveable)player.Car).MoveLeft();
                    return;
                case Keys.Right:
                    ((IMoveable)player.Car).MoveRight();
                    return;
                case Keys.Down:
                    ((IMoveable)player.Car).MoveDown();
                    return;
                default:
                    return;
            }
        }

        private static void SecondTypeControls(IPlayer player, PreviewKeyDownEventArgs e)
        {
            if (player == null)
            {
                return;
            }
            Ui.Instance().RequireScreenUpdate();
            switch (e.KeyData)
            {
                case Keys.W:
                    ((IMoveable)player.Car).MoveUp();
                    return;
                case Keys.A:
                    ((IMoveable)player.Car).MoveLeft();
                    return;
                case Keys.D:
                    ((IMoveable)player.Car).MoveRight();
                    return;
                case Keys.S:
                    ((IMoveable)player.Car).MoveDown();
                    return;
                default:
                    return;
            }
        }
    }
}
