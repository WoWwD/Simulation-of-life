using SimulatorOfLive.Logic.Abstract_model;
using SimulatorOfLive.Logic.Controller;
using SimulatorOfLive.Logic.Model;
using SimulatorOfLive.Logic.Model.Cell;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace SimulatorOfLive.View
{
    public partial class Form1 : Form
    {
        private static Controller controller = new Controller();
        private static Pen pen = new Pen(Color.Black, 1);
        private const int CountOfCells = 10;
        private Graphics graphics;
        public Form1()
        {
            InitializeComponent();
            controller.EditSpeedOfGame(243);
            controller.AddFirstCells(CountOfCells, GameZonePictureBox.Width, GameZonePictureBox.Height);
            GameZonePictureBox.Image = new Bitmap(GameZonePictureBox.Width, GameZonePictureBox.Height);
            graphics = Graphics.FromImage(GameZonePictureBox.Image);
            graphics.Clear(Color.LightGray);
           
            RefreshData();
            
        }
        private void RefreshData()
        {
            foreach (FormOfCell cell in controller.cells)
            {
                if (cell is CarnivorousLowCell)
                {
                    graphics.FillEllipse(Brushes.BlueViolet, cell.X, cell.Y, cell.Width, cell.Height);
                }
                if (cell is CarnivorousMediumCell)
                {
                    graphics.FillEllipse(Brushes.Blue, cell.X, cell.Y, cell.Width, cell.Height);
                }
                if (cell is CarnivorousHighCell)
                {
                    graphics.FillEllipse(Brushes.Brown, cell.X, cell.Y, cell.Width, cell.Height);
                }
                if (cell is HerbivoreLowCell)
                {
                    graphics.FillEllipse(Brushes.DarkGreen, cell.X, cell.Y, cell.Width, cell.Height);
                    //float x = cell.X - cell.Overview / 2;
                    //float y = cell.Y - cell.Overview / 2;
                    //float width = 2 * cell.Overview / 2;
                    //float height = 2 * cell.Overview / 2;
                    //graphics.DrawEllipse(pen, x, y, width, height);
                }
                if (cell is HerbivoreMediumCell)
                {
                    graphics.FillEllipse(Brushes.DarkOliveGreen, cell.X, cell.Y, cell.Width, cell.Height);
                }
                if (cell is HerbivoreHighCell)
                {
                    graphics.FillEllipse(Brushes.Green, cell.X, cell.Y, cell.Width, cell.Height);
                }
            }
            foreach (var e in controller.eat)
            {
                graphics.FillRectangle(Brushes.Green, e.X, e.Y, e.Width, e.Height);
            }
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
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            graphics.Clear(Color.LightGray);
            RefreshData();
            controller.AddEat(GameZonePictureBox.Width, GameZonePictureBox.Height);
            controller.MoveCells(GameZonePictureBox.Width, GameZonePictureBox.Height);
            controller.Eating();
            controller.Evolution();
            
            GameZonePictureBox.Refresh();
            label1.Text = $"Количество клеток {controller.cells.Count} из {CountOfCells}";
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (trackBar1.Value == 1)
            {
                controller.EditSpeedOfGame(243);
                SpeedOfGamesLabel.Text = $"Скорость игры: {trackBar1.Value}x";
            }
            if (trackBar1.Value == 2)
            {
                controller.EditSpeedOfGame(81);
                SpeedOfGamesLabel.Text = $"Скорость игры: {trackBar1.Value}x";
            }
            if (trackBar1.Value == 3)
            {
                controller.EditSpeedOfGame(27);
                SpeedOfGamesLabel.Text = $"Скорость игры: {trackBar1.Value}x";
            }
            if (trackBar1.Value == 4)
            {
                controller.EditSpeedOfGame(9);
                SpeedOfGamesLabel.Text = $"Скорость игры: {trackBar1.Value}x";
            }
        }
        private void GameZonePictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (timer1.Enabled)
            {
                if (e.Button == MouseButtons.Left)
                {
                    controller.AddingDeletingCellsThroughMouse(e.Location.X, e.Location.Y, controller.cells);
                    RefreshData();
                }
            }
        }
    }
}