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
            DoubleBuffered = true;
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
            switch (e.KeyData)
            {
                case Keys.Up:
                    player.Car.MoveUp();
                    break;
                case Keys.Left:
                    player.Car.MoveLeft();
                    break;
                case Keys.Right:
                    player.Car.MoveRight();
                    break;
                case Keys.Down:
                    player.Car.MoveDown();
                    break;
                default:
                    return;
            }
            Ui.Instance().RequireScreenUpdate();
        }

        private static void SecondTypeControls(IPlayer player, PreviewKeyDownEventArgs e)
        {
            if (player == null)
            {
                return;
            }
            switch (e.KeyData)
            {
                case Keys.W:
                    player.Car.MoveUp();
                    break;
                case Keys.A:
                    player.Car.MoveLeft();
                    break;
                case Keys.D:
                    player.Car.MoveRight();
                    break;
                case Keys.S:
                    player.Car.MoveDown();
                    break;
                default:
                    return;
            }
            Ui.Instance().RequireScreenUpdate();
        }
    }
}
