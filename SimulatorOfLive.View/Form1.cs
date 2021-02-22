using SimulatorOfLive.Logic.Controller;
using SimulatorOfLive.Logic.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulatorOfLive.View
{
    public partial class Form1 : Form
    {
        public int speedOfGame = 243;
        private static Bitmap bmp = new Bitmap(1262, 589);
        private static Graphics graphics = Graphics.FromImage(bmp);
        private static Controller controller = new Controller();
        public Form1()
        {
            InitializeComponent();
            graphics.FillRectangle(Brushes.LightGray, 0, 0, GameZonePictureBox.Width, GameZonePictureBox.Height);
            GameZonePictureBox.Image = bmp;
            controller.AddCellsLow(500, GameZonePictureBox.Width, GameZonePictureBox.Height);
        }
        private void StartGameButton_Click(object sender, EventArgs e)
        {
            StartGameButton.Enabled = false;
            timer1.Start();
            
        }
        private void ResetGameButton_Click(object sender, EventArgs e)
        {

        }
        private void PauseGameButton_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            StartGameButton.Enabled = true;
            trackBar1.Enabled = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            trackBar1.Enabled = false;
            graphics.Clear(Color.LightGray);
            controller.Move(GameZonePictureBox.Width, GameZonePictureBox.Height, speedOfGame);
            for (int i = 0; i < controller.lowcells.Count; i++)
            {
                GameZonePictureBox.Image = bmp;
                graphics.FillEllipse(Brushes.BlueViolet, controller.lowcells[i].X, controller.lowcells[i].Y, controller.lowcells[i].Width, controller.lowcells[i].Height);
            }
            if (controller.lowcells.Count < 500)
            {
                timer1.Stop();
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            SpeedOfGamesLabel.Text = $"Скорость игры: {trackBar1.Value}x";
            if (trackBar1.Value == 1)
            {
                speedOfGame = 243;
            }
            if (trackBar1.Value == 2)
            {
                speedOfGame = 81;
            }
            if (trackBar1.Value == 3)
            {
                speedOfGame = 27;
            }
            if (trackBar1.Value == 4)
            {
                speedOfGame = 9;
            }
        }
    }
}