﻿using SimulatorOfLive.Logic.Abstract_model;
using SimulatorOfLive.Logic.Controller;
using SimulatorOfLive.Logic.Model;
using SimulatorOfLive.Logic.Model.Cell;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimulatorOfLive.View
{
    public partial class Form1 : Form
    {
        private const int CountOfCells = 300;
        private Graphics graphics;
        private static Controller controller = new Controller();
        public Form1()
        {
            InitializeComponent();
            controller.EditSpeedOfGame(243);
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
                }
                if (cell is HerbivoreMediumCell)
                {
                    graphics.FillEllipse(Brushes.DarkSeaGreen, cell.X, cell.Y, cell.Width, cell.Height);
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
            controller.AddFirstCells(CountOfCells, GameZonePictureBox.Width, GameZonePictureBox.Height);
            GameZonePictureBox.Image = new Bitmap(GameZonePictureBox.Width, GameZonePictureBox.Height);
            graphics = Graphics.FromImage(GameZonePictureBox.Image);
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
            controller.MoveCells(GameZonePictureBox.Width, GameZonePictureBox.Height);
            controller.Eating();
            controller.Evolution();
            controller.AddEat(GameZonePictureBox.Width, GameZonePictureBox.Height);
            RefreshData();
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
            //if (timer1.Enabled)
            //{
            //    if (e.Button == MouseButtons.Left)
            //    {
            //        controller.AddingDeletingCellsThroughMouse(e.Location.X, e.Location.Y, controller.cells);
            //        RefreshCells(controller.cells);
            //    }
            //}
        }
    }
}