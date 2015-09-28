using System;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

using Data;

using Services.Services.Objects;
using Services.Services.Objects.Singletons;

namespace GameForm
{
    public partial class MainForm : Form
    {
        Thread paintThread;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainBox_KeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            var drawable = new Car();
            Ui.Instance().AddDrawableItem(drawable);
            Ui.Instance().AddDrawableItem(new RivalCar());
            this.Name = Globals.PROGRAM_NAME;
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
        
        }
    }
}
