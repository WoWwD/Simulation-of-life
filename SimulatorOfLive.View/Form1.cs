using SimulatorOfLive.Logic.Abstract_model;
using SimulatorOfLive.Logic.Controller;
using SimulatorOfLive.Logic.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SimulatorOfLive.View
{
    public partial class Form1 : Form
    {
        private const int CountOfCells = 750;
        private static Bitmap bmp = new Bitmap(1262, 589);
        private static Graphics graphics = Graphics.FromImage(bmp);
        private static Controller controller = new Controller();
        private void RefreshCells<T>(List<T> cells) where T: FormOfCell
        {
            foreach (var cell in cells)
            {
                if (cell is CarnivorousLowCell)
                {
                    GameZonePictureBox.Image = bmp;
                    graphics.FillEllipse(Brushes.BlueViolet, cell.X, cell.Y, cell.Width, cell.Height);
                }
                if (cell is CarnivorousMediumCell)
                {
                    GameZonePictureBox.Image = bmp;
                    graphics.FillEllipse(Brushes.Blue, cell.X, cell.Y, cell.Width, cell.Height);
                }
                if (cell is CarnivorousHighCell)
                {
                    GameZonePictureBox.Image = bmp;
                    graphics.FillEllipse(Brushes.Brown, cell.X, cell.Y, cell.Width, cell.Height);
                }
                if (cell is HerbivoreLowCell)
                {
                    GameZonePictureBox.Image = bmp;
                    graphics.FillEllipse(Brushes.Black, cell.X, cell.Y, cell.Width, cell.Height);
                }
            }
            label1.Text = $"Количество клеток: {cells.Count} из {CountOfCells}";
        }
        private void RefreshEat<T>(List<T> eat) where T : Eat
        {
            if (eat.Count != 0)
            {
                foreach (var e in eat)
                {
                    if (e is Eat)
                    {
                        GameZonePictureBox.Image = bmp;
                        graphics.FillRectangle(Brushes.Green, e.X, e.Y, e.Width, e.Height);
                    }
                }
            }
        }
        public Form1()
        {
            InitializeComponent();
            graphics.FillRectangle(Brushes.LightGray, 0, 0, GameZonePictureBox.Width, GameZonePictureBox.Height);
            GameZonePictureBox.Image = bmp;
            controller.AddFirstCells(CountOfCells, GameZonePictureBox.Width, GameZonePictureBox.Height, controller.cells);
            controller.EditSpeedOfGame(243);
        }
        private void StartGameButton_Click(object sender, EventArgs e)
        {
            StartGameButton.Enabled = false;
            timer1.Start();
        }
        private void ResetGameButton_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            controller.DeleteAllCells(controller.cells);
            RefreshCells(controller.cells);
            controller.AddFirstCells(CountOfCells, GameZonePictureBox.Width, GameZonePictureBox.Height, controller.cells);
            timer1.Start();
        }
        private void PauseGameButton_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            StartGameButton.Enabled = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            graphics.Clear(Color.LightGray);
            controller.AddEat(GameZonePictureBox.Width, GameZonePictureBox.Height, controller.eat);
            RefreshEat(controller.eat);
            RefreshCells(controller.cells);
            controller.Move(GameZonePictureBox.Width, GameZonePictureBox.Height, controller.SpeedOfGame, controller.cells);
            controller.Eating();
            controller.EvolutionOfCells(controller.cells);
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
                    RefreshCells(controller.cells);
                }
            }
        }
    }
}