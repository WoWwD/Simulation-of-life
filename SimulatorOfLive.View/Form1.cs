using SimulationOfLife.Logic.Controller;
using SimulationOfLife.Logic.Model;
using SimulationOfLife.Logic.Model.Cell;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SimulationOfLife.View
{
    public partial class Form1 : Form
    {
        private static Controller controller = new Controller();
        private static Pen pen = new Pen(Color.Black, 1);
        private Dictionary<string, int> dict = new Dictionary<string, int>();
        private Graphics graphics;
        private int CountOfDivision = 0;
        public Form1()
        {
            InitializeComponent();
            groupBox1.Visible = false;
            StartGameButton.Enabled = false;
            PauseGameButton.Enabled = false;
            SaveGameButton.Enabled = false;
            GameZonePictureBox.Image = new Bitmap(GameZonePictureBox.Width, GameZonePictureBox.Height);
            graphics = Graphics.FromImage(GameZonePictureBox.Image);
            graphics.Clear(Color.WhiteSmoke);
            timer1.Interval = 500;
        }
        #region Кнопки

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            PauseGameButton.Enabled = true;
            SaveGameButton.Enabled = false;
            LoadGameButton.Enabled = false;
            NewGameButton.Enabled = false;
            StartGameButton.Enabled = false;
            timer1.Start();
        }
        private void PauseGameButton_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            StartGameButton.Enabled = true;
            SaveGameButton.Enabled = true;
            LoadGameButton.Enabled = true;
            NewGameButton.Enabled = true;
            PauseGameButton.Enabled = false;
        }
        private void SaveGameButton_Click(object sender, EventArgs e)
        {
            controller.Serializable();
        }
        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.WhiteSmoke);
            controller.DeSerializable();
            RefreshData();
            GameZonePictureBox.Refresh();
            StartGameButton.Enabled = true;
        }
        private void NewGameButton_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.WhiteSmoke);
            controller.StartNewGame();
            controller.AddFirstCells(SettingsGame.CountOfCells, GameZonePictureBox.Width, GameZonePictureBox.Height);
            RefreshData();
            GameZonePictureBox.Refresh();
            StartGameButton.Enabled = true;
            groupBox1.Visible = true;
        }

        #endregion
        private void RefreshData()
        {
            double c = 0, h = 0, o = 0;
            foreach (var cell in controller.cells)
            {
                if (cell is CarnivorousLowCell || cell is CarnivorousMediumCell || cell is CarnivorousHighCell)
                {
                    graphics.FillEllipse(Brushes.Crimson, cell.X, cell.Y, cell.Width, cell.Height);
                    c++;
                }
                if (cell is HerbivoreLowCell || cell is HerbivoreMediumCell || cell is HerbivoreHighCell)
                {
                    graphics.FillEllipse(Brushes.Green, cell.X, cell.Y, cell.Width, cell.Height);
                    //graphics.DrawEllipse(pen, cell.X - (cell.Overview / 2), cell.Y - (cell.Overview / 2), cell.Overview, cell.Overview);
                    h++;
                }
                if (cell is OmnivoreLowCell || cell is OmnivoreMediumCell || cell is OmnivoreHighCell)
                {
                    graphics.FillEllipse(Brushes.BlueViolet, cell.X, cell.Y, cell.Width, cell.Height);
                    o++;
                }
            }
            foreach (var f in controller.food)
            {
                graphics.FillRectangle(Brushes.Green, f.X, f.Y, f.Width, f.Height);
            }
            bool r = controller.Division();
            if (r == true)
            {
                CountOfDivision++;
                CountOfDivisionLabel.Text = $"Количество делений: {CountOfDivision}";
            }
            label1.Text = $"Количество клеток {controller.cells.Count} из {SettingsGame.CountOfCells}";
            carni.Text = $"Плотоядные: {Math.Round(c / controller.cells.Count, 3) * 100}%";
            herbi.Text = $"Травоядные: {Math.Round(h / controller.cells.Count, 3) * 100}%";
            omni.Text = $"Всеядные: {Math.Round(o / controller.cells.Count, 3) * 100}%";
        }
        private void CountingCountOfDivision()
        {
            int count = 0;
            string name = "no value";
            dict.Clear();
            foreach (var cell in controller.cells)
            {
                if (dict.ContainsKey(cell.ID))
                {
                    dict[cell.ID]++;
                }
                else
                {
                    dict.Add(cell.ID, 1);
                }
            }
            foreach (var cell in dict)
            {
                if (cell.Value > count)
                {
                    count = cell.Value;
                    name = cell.Key;
                }
            }
            IdCellLabel.Text = $"Наибольшее количество живых потомков у {name} : {count}";
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            graphics.Clear(Color.WhiteSmoke);
            RefreshData();
            controller.AddFood(GameZonePictureBox.Width, GameZonePictureBox.Height);
            controller.Move(GameZonePictureBox.Width, GameZonePictureBox.Height);
            controller.Eating();
            controller.Evolution();
            CountingCountOfDivision();
            GameZonePictureBox.Refresh();
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (trackBar1.Value == 1)
            {
                timer1.Interval = 500;
                SpeedOfGamesLabel.Text = "Speed of game: very low";
            }
            if (trackBar1.Value == 2)
            {
                timer1.Interval = 300;
                SpeedOfGamesLabel.Text = "Speed of game: low";
            }
            if (trackBar1.Value == 3)
            {
                timer1.Interval = 100;
                SpeedOfGamesLabel.Text = "Speed of game: medium";
            }
            if (trackBar1.Value == 4)
            {
                timer1.Interval = 50;
                SpeedOfGamesLabel.Text = "Speed of game: high";
            }
            if (trackBar1.Value == 5)
            {
                timer1.Interval = 10;
                SpeedOfGamesLabel.Text = "Speed of game: very high";
            }
            //if (trackBar1.Value == 1)
            //{
            //    timer1.Interval = 100;
            //    SpeedOfGamesLabel.Text = $"Скорость игры: {trackBar1.Value}x";
            //}
            //if (trackBar1.Value == 2)
            //{
            //    timer1.Interval = 75;
            //    SpeedOfGamesLabel.Text = $"Скорость игры: {trackBar1.Value}x";
            //}
            //if (trackBar1.Value == 3)
            //{
            //    timer1.Interval = 50;
            //    SpeedOfGamesLabel.Text = $"Скорость игры: {trackBar1.Value}x";
            //}
            //if (trackBar1.Value == 4)
            //{
            //    timer1.Interval = 25;
            //    SpeedOfGamesLabel.Text = $"Скорость игры: {trackBar1.Value}x";
            //}
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