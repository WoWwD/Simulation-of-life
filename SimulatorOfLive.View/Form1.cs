using SimulatorOfLive.Logic.Controller;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimulatorOfLive.View
{
    public partial class Form1 : Form
    {
        public int speedOfGame = 243;
        public int killed = 0;
        private static Bitmap bmp = new Bitmap(1262, 589);
        private static Graphics graphics = Graphics.FromImage(bmp);
        private static Controller controller = new Controller();
        public Form1()
        {
            InitializeComponent();
            label1.Visible = false;
            graphics.FillRectangle(Brushes.LightGray, 0, 0, GameZonePictureBox.Width, GameZonePictureBox.Height);
            GameZonePictureBox.Image = bmp;
            controller.AddFirstCells(350, GameZonePictureBox.Width, GameZonePictureBox.Height, controller.cells);  
        }
        private void StartGameButton_Click(object sender, EventArgs e)
        {
            StartGameButton.Enabled = false;
            label1.Visible = true;
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
            controller.Move(GameZonePictureBox.Width, GameZonePictureBox.Height, speedOfGame, controller.cells);
            controller.AddMediumCells();
            controller.AddHighCells();
            for (int i = 0; i < controller.cells.Count; i++)
            {
                if (controller.cells[i].Width == 10 && controller.cells[i].Height == 10)
                {
                    GameZonePictureBox.Image = bmp;
                    graphics.FillEllipse(Brushes.Brown, controller.cells[i].X, controller.cells[i].Y, controller.cells[i].Width, controller.cells[i].Height);

                }
                if (controller.cells[i].Width == 8 && controller.cells[i].Height == 8)
                {
                    GameZonePictureBox.Image = bmp;
                    graphics.FillEllipse(Brushes.Blue, controller.cells[i].X, controller.cells[i].Y, controller.cells[i].Width, controller.cells[i].Height);
                    
                }
                if (controller.cells[i].Width == 6 && controller.cells[i].Height == 6)
                {
                    GameZonePictureBox.Image = bmp;
                    graphics.FillEllipse(Brushes.BlueViolet, controller.cells[i].X, controller.cells[i].Y, controller.cells[i].Width, controller.cells[i].Height);
                }
                label1.Text = $"Вышло за границу: {350 - controller.cells.Count} из {350}";
                
            }
            //if (controller.cells.Count < 250 || controller.cells.Count > 250)
            //{
            //    timer1.Stop();
            //}
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