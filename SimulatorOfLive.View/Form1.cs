using SimulatorOfLive.Logic.Abstract_model;
using SimulatorOfLive.Logic.Controller;
using SimulatorOfLive.Logic.Controller.Creatures;
using SimulatorOfLive.Logic.Model;
using SimulatorOfLive.Logic.Model.Cell;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace SimulatorOfLive.View
{
//    if (cell is CarnivorousLowCell)
//                {
//                    graphics.FillEllipse(Brushes.DarkRed, cell.X, cell.Y, cell.Width, cell.Height);
//                }
//if (cell is CarnivorousMediumCell)
//{
//    graphics.FillEllipse(Brushes.Red, cell.X, cell.Y, cell.Width, cell.Height);
//}
//if (cell is CarnivorousHighCell)
//{
//    graphics.FillEllipse(Brushes.OrangeRed, cell.X, cell.Y, cell.Width, cell.Height);
//}
//if (cell is HerbivoreLowCell)
//{
//    graphics.FillEllipse(Brushes.DarkGreen, cell.X, cell.Y, cell.Width, cell.Height);
//    //float x = cell.X - cell.Overview / 2;
//    //float y = cell.Y - cell.Overview / 2;
//    //float width = 2 * cell.Overview / 2;
//    //float height = 2 * cell.Overview / 2;
//    //graphics.DrawEllipse(pen, x, y, width, height);
//}
//if (cell is HerbivoreMediumCell)
//{
//    graphics.FillEllipse(Brushes.DarkOliveGreen, cell.X, cell.Y, cell.Width, cell.Height);
//}
//if (cell is HerbivoreHighCell)
//{
//    graphics.FillEllipse(Brushes.Green, cell.X, cell.Y, cell.Width, cell.Height);
//}
//if (cell is OmnivoreLowCell)
//{
//    graphics.FillEllipse(Brushes.DarkBlue, cell.X, cell.Y, cell.Width, cell.Height);
//}
//if (cell is OmnivoreMediumCell)
//{
//    graphics.FillEllipse(Brushes.Blue, cell.X, cell.Y, cell.Width, cell.Height);
//}
//if (cell is OmnivoreHighCell)
//{
//    graphics.FillEllipse(Brushes.BlueViolet, cell.X, cell.Y, cell.Width, cell.Height);
//}
public partial class Form1 : Form
    {
        private static Controller controller = new Controller();
        private static Pen pen = new Pen(Color.Black, 1);
        private Graphics graphics;
        private int Tick;
        private int CountOfDivision = 0;
        public Form1()
        {
            InitializeComponent();
            
            //controller.EditSpeedOfGame(243);
            controller.AddFirstCells(SettingsGame.CountOfCells, GameZonePictureBox.Width, GameZonePictureBox.Height);
            GameZonePictureBox.Image = new Bitmap(GameZonePictureBox.Width, GameZonePictureBox.Height);
            graphics = Graphics.FromImage(GameZonePictureBox.Image);
            graphics.Clear(Color.LightGray);
           
            RefreshData();
            
        }
        private void RefreshData()
        {
            foreach (var cell in controller.cells.cells)
            {
                if (cell is CarnivorousLowCell || cell is CarnivorousMediumCell || cell is CarnivorousHighCell)
                {
                    graphics.FillEllipse(Brushes.Crimson, cell.X, cell.Y, cell.Width, cell.Height);
                }
                if (cell is HerbivoreLowCell || cell is HerbivoreMediumCell || cell is HerbivoreHighCell)
                {
                    graphics.FillEllipse(Brushes.Green, cell.X, cell.Y, cell.Width, cell.Height);
                }
                if (cell is OmnivoreLowCell || cell is OmnivoreMediumCell || cell is OmnivoreHighCell)
                {
                    graphics.FillEllipse(Brushes.BlueViolet, cell.X, cell.Y, cell.Width, cell.Height);
                }
            }
            foreach (var e in controller.eat)
            {
                graphics.FillRectangle(Brushes.Green, e.X, e.Y, e.Width, e.Height);
            }
        }
        private void CountCells()
        {
            double c = 0, h = 0, o = 0;
            for (int i = 0; i < controller.cells.cells.Count; i++)
            {
                if (controller.cells.cells[i] is CarnivorousLowCell || controller.cells.cells[i] is CarnivorousMediumCell || controller.cells.cells[i] is CarnivorousHighCell)
                {
                    c++;
                }
                if (controller.cells.cells[i] is HerbivoreLowCell || controller.cells.cells[i] is HerbivoreMediumCell || controller.cells.cells[i] is HerbivoreHighCell)
                {
                    h++;
                }
                if (controller.cells.cells[i] is OmnivoreLowCell || controller.cells.cells[i] is OmnivoreMediumCell || controller.cells.cells[i] is OmnivoreHighCell)
                {
                    o++;
                }
                carni.Text = $"Плотоядные: {Math.Round(c / controller.cells.cells.Count, 3)* 100}%";
                herbi.Text = $"Травоядные: {Math.Round(h / controller.cells.cells.Count, 3) * 100}%";
                omni.Text = $"Всеядные: {Math.Round(o / controller.cells.cells.Count, 3) * 100}%";
            }
        }
        private void StartGameButton_Click(object sender, EventArgs e)
        {
            timer1.Interval = 500;
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
            controller.Eating(GameZonePictureBox.Width, GameZonePictureBox.Height);
            controller.EvolutionCells();
            var r = controller.Division();
            label1.Text = $"Количество клеток {controller.cells.cells.Count} из {SettingsGame.CountOfCells}";
            if((Tick % 2000) == 0)
            {
                CountCells();
            }
            if (r == true)
            {
                CountOfDivision++;
                CountOfDivisionLabel.Text = $"Количество делений: {CountOfDivision}";
            }
            Tick += timer1.Interval;
            GameZonePictureBox.Refresh();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (trackBar1.Value == 1)
            {
                timer1.Interval = 500;
                SpeedOfGamesLabel.Text = $"Скорость игры: {trackBar1.Value}x";
            }
            if (trackBar1.Value == 2)
            {
                timer1.Interval = 200;
                SpeedOfGamesLabel.Text = $"Скорость игры: {trackBar1.Value}x";
            }
            if (trackBar1.Value == 3)
            {
                timer1.Interval = 100;
                SpeedOfGamesLabel.Text = $"Скорость игры: {trackBar1.Value}x";
            }
            if (trackBar1.Value == 4)
            {
                timer1.Interval = 10;
                SpeedOfGamesLabel.Text = $"Скорость игры: {trackBar1.Value}x";
            }
        }
        private void GameZonePictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (timer1.Enabled)
            {
                if (e.Button == MouseButtons.Left)
                {
                    controller.AddCellsThroughMouse(e.Location.X, e.Location.Y);
                    RefreshData();
                }
                if (e.Button == MouseButtons.Right)
                {
                    controller.AddEatThroughMouse(e.Location.X, e.Location.Y);
                    RefreshData();
                }
            }
        }
    }
}